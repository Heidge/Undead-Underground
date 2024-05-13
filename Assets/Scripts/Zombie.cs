using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public int hp = 100;
    public Animator animator;

    public void TakeDamage(int damage)
    {
        if (hp > 0)
        {
            hp -= damage;
            if (hp > 0) {
                if (animator != null && animator.isActiveAndEnabled)
                    animator.SetTrigger("hit");
            }
            else {
                if (animator != null && animator.isActiveAndEnabled)
                    animator.SetTrigger("dead");

                Waves.instance.zombieNumber--;
                if (Waves.instance.zombieNumber == 0)
                    StartCoroutine(Waves.instance.WavesTransition());
                
                StartCoroutine(DestroyZombie(5f));
            }
        }
    }

    IEnumerator DestroyZombie(float delay) {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
