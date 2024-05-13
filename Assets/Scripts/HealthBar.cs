using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public PlayerHealth playerHealth;
	private Slider healthSlider;

	private void Start()
	{
		healthSlider = GetComponent<Slider>();
	}

	private void Update()
	{
		if (playerHealth != null && healthSlider != null)
		{
			healthSlider.value = (float)playerHealth.currentHealth / playerHealth.maxHealth;
		}

	}
}