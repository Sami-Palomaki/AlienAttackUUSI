using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Animator anim;
    private Health _health;
    private PlayerController playerController;


    void Start()
    {
        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
        playerController = GetComponent<PlayerController>();
        anim = GetComponentInChildren<Animator>();
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
            playerController.isDead = true;
            anim.SetTrigger("dying");
            Invoke("GameOver", 5f);
        }
    }

    void GameOver()
    {       
        Debug.Log("game over");
        //SceneManager.LoadScene("GameOver");
    }
}
