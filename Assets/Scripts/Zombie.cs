using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// This class defines the behavior of a zombie in the game
public class Zombie : MonoBehaviour
{
    // The health points of the zombie
    public int hp = 100;

    // The animator component attached to the zombie
    public Animator animator;

    // This method is called when the zombie takes damage
    public void TakeDamage(int damage)
    {
        // If the zombie still has health points
        if (hp > 0)
        {
            // Subtract the damage from the zombie's health points
            hp -= damage;

            // If the zombie still has health points after taking damage
            if (hp > 0)
            {
                // If the animator component is not null and is enabled
                if (animator != null && animator.isActiveAndEnabled)
                    // Trigger the "hit" animation
                    animator.SetTrigger("hit");
            }
            else
            {
                // If the animator component is not null and is enabled
                if (animator != null && animator.isActiveAndEnabled)
                    // Trigger the "dead" animation
                    animator.SetTrigger("dead");

                // Decrease the number of zombies in the current wave
                Waves.instance.zombieNumber--;

                // If there are no more zombies in the current wave
                if (Waves.instance.zombieNumber == 0)
                {
                    Debug.Log("0 zombie, new wave");
                    // Start the transition to the next wave
                    StartCoroutine(Waves.instance.WavesTransition());
                }
                    
                // Start the coroutine to destroy the zombie after a delay
                StartCoroutine(DestroyZombie(5f));
            }
        }
    }

    // This coroutine destroys the zombie after a delay
    IEnumerator DestroyZombie(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Destroy the zombie GameObject
        Destroy(gameObject);
    }
}
