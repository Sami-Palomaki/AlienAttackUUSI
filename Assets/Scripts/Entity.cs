using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public virtual void TakeDamage(float dmg)
    {
        // Instantiatessa jotain vikaa, anna olla kommentoituna
        //Instantiate(blood, transform.position, Quaternion.identity);
        health -= dmg;

        if (health <= 0)
        {
            // anim.SetBool("isDying", true);
            Die();
        }
    }

    public virtual void Die()
    {
        // agent.isStopped = true; // Pysäyttää NavMeshAgentin liikkumisen
        // Invoke("DestroyGameObject", 35f);
        // Destroy(gameObject);
    }
}
