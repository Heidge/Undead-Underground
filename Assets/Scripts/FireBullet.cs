using UnityEngine;
using UnityEngine.InputSystem;

public class FireBullet : MonoBehaviour
{
    public InputActionProperty fireAction;

    public int damage = 50;
    private bool cooldown = true;

    public LayerMask mask;
    private RaycastHit hit;

    void Update()
    {
        float fire = fireAction.action.ReadValue<float>();

        if (cooldown && fire > 0.8) {
            //Fire
            cooldown = false;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, mask)) {
                if (hit.collider.tag == "Zombie")
                {
                    Debug.Log("Hit: " + hit.collider.name);
                    Zombie zombie = hit.collider.gameObject.GetComponent<Zombie>();
                    if (zombie != null)
                        zombie.TakeDamage(damage);
                    else
                        Debug.LogError("Zombie script not found on the zombie GameObject.");
                }
            }
        }

        if (fire < 0.2)
            cooldown = true;
    }
}
