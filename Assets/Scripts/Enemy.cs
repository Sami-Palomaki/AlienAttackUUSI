using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : Entity
{
    public float expOnDeath;
    public Transform target;
    public float maxSpeed = 5;
    public float radius = 1;
    public bool isWalking = false;
    public int damage = 15;
    public float attackCD;
    public Transform attackPos;
    public string zombieSound;
    public Slider healthBar;
    private float dist;
    private float lastAttackTime = 2f; // Alustetaan aika niin pieneksi, että vihollinen voi hyökätä heti alussa
    bool isDead = false;
    NavMeshAgent agent;
    Animator anim;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        healthBar = GetComponentInChildren<Slider>();
        healthBar.maxValue = maxHealth;
        // Aseta terveyspalkki täyteen alkutilanteessa
        health = maxHealth;
        healthBar.value = health;
    }

    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);
        // healthBar.value = health;

        if (dist <= agent.stoppingDistance)
        {
            if (Time.time - lastAttackTime > attackCD) // Tarkistetaan, onko kulunut tarpeeksi aikaa viime hyökkäyksestä
            {
                lastAttackTime = Time.time; // Päivitetään viime hyökkäyksen aika
                anim.SetBool("isAttacking", true);
                //anim.SetTrigger("attack");
                
                StartAttack();
            }
            else
            {
                anim.SetBool("isAttacking", false);
            }
        }
        agent.SetDestination(target.position);
    }

    public override void TakeDamage(float dmg)
    {
        health -= dmg;
        healthBar.DOValue(health, 0.2f);

        if (health <= 0)
        {
            // anim.SetBool("isDying", true);
            Die();
        }
    }

    public override void Die()
    {
        player.AddExperience(expOnDeath);
        base.Die();
    }

    public void StartAttack()
    {
        if (isDead)
        {
            return;
        }
        else
        {

            AudioManager.instance.Play(zombieSound, this.gameObject);
            FaceTarget();       // Vihollinen katsoo sinua päin kun hyökkää
        
            // anim.SetTrigger("attack");
            DoDamage();
            
        }
    }

    public void AttackAnimationEvent()
    {
        Player playerHealth = FindObjectOfType<Player>();
        
        if (playerHealth != null)
        {    
            playerHealth.TakeDamage(damage);
        }  
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    public void DoDamage()
    {
        Debug.Log("Tuleeko DODAMAGE metodiin?");
        AttackAnimationEvent();
    }

    void OnDrawGizmosSelected()                             // Vihollisen hyökkäys-gizmot
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, radius);
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.TryGetComponent<Player>(out Player player))
    //     {
    //         player.TakeDamage(10);
    //     }
    // }
}
