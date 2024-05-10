using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public int hp = 100;
    public Animator zombieAnimator;
    public Waves instance;
    
    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("Zombie dead");
            instance.zombieNumber--;
            zombieAnimator.SetBool("isDead", true);
        }
    }

    public void TakeDamage(int damage)
    {
        if (hp > 0)
        {
            zombieAnimator.Play("Hit");
            hp -= damage;
        }
            
    }
}
