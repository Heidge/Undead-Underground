using UnityEngine;

public class ZombieCounter : MonoBehaviour
{
	public float checkInterval = 3f;
	public float radius = 3f;

	private PlayerHealth playerHealth;

	private void Start()
	{
		playerHealth = GetComponent<PlayerHealth>();
		InvokeRepeating(nameof(CheckZombies), 0f, checkInterval);
	}

	private void CheckZombies()
	{
		Collider[] zombies = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Zombie"));

		int zombieCount = zombies.Length;

		playerHealth.TakeDamage(zombieCount * 5);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, radius);
	}
}