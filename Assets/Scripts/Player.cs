using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider healthBar;
    private int level;
    private float currentLevelExperience;
    private float experienceToLevel;
    private GameGUI gui;
    public string hurtSound;
    public GameObject player;
    Animator anim;
    bool isGameOver = false; // Lisää tämä muuttuja

    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        //anim = GetComponentInChildren<Animator>();
        gui = GameObject.FindGameObjectWithTag("GUI").GetComponent<GameGUI>();
        LevelUp();
    }

    public void AddExperience(float exp)
    {
        currentLevelExperience += exp;
        if (currentLevelExperience >= experienceToLevel)
        {
            currentLevelExperience -= experienceToLevel;
            LevelUp();
        }

        gui.SetPlayerExperience(currentLevelExperience/experienceToLevel, level);
    }

    private void LevelUp()
    {
        level++;
        experienceToLevel = level * 100 + Mathf.Pow(level * 2,2);

        AddExperience(0);
    }

    public void TakeDamage(float damage)
    {
        if (player != null && health > 0) {

        health -= damage;
        healthBar.value = health;

        AudioManager.instance.Play(hurtSound, this.gameObject);
        }


        if (health <= 0)
        {
            Destroy(this.gameObject);
            // healthBar.value = health;
            // isGameOver = true;
            anim.SetTrigger("dying");
            // StartCoroutine(GameOverAfterDelay(5f));
            //GameOver();
        }
    }
}
