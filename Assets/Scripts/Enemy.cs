using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : Entity
{
    [SerializeField] private float disappearDelay = 15f;
    public Transform target;
    public float expOnDeath;
    public float maxSpeed = 5;
    public float radius = 1;
    public int damage = 15;
    public float attackCD;
    public string zombieSound;
    public Slider healthBar;
    NavMeshAgent agent;
    Animator anim;
    private float dist;
    private float lastAttackTime = 2f; // Alustetaan aika niin pieneksi, että vihollinen voi hyökätä heti alussa
    private Player player;
    private bool enemy_is_dead;
    bool isDead = false;

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

        if (dist <= agent.stoppingDistance)
        {
            if (Time.time - lastAttackTime > attackCD) // Tarkistetaan, onko kulunut tarpeeksi aikaa viime hyökkäyksestä
            {
                lastAttackTime = Time.time; // Päivitetään viime hyökkäyksen aika
                anim.SetBool("isAttacking", true);
                
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
            anim.SetBool("isDying", true);
            Die();
        }
    }

    public override void Die()
    {
        agent.isStopped = true;
        enemy_is_dead = true;
        player.AddExperience(expOnDeath);

        // Lisää viholliselle aikaviive ennen katoamista
        StartCoroutine(DisappearAfterDelay(disappearDelay));

        base.Die();
    }

    public void StartAttack()
    {
        if (enemy_is_dead)
        {
            return;
        }
        else
        {
            AudioManager.instance.Play(zombieSound, this.gameObject);
            FaceTarget();       // Vihollinen katsoo sinua päin kun hyökkää
        
            DoDamage(); 
        }
    }

    public void DoDamage()
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

    private IEnumerator DisappearAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        // Tuhotaan vihollinen
        Destroy(gameObject);
    }
}
