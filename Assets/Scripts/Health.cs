// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using TMPro;


// public class Health : MonoBehaviour
// {
//     // public float health = 100f;
//     // public float maxHealth = 100f;
//     public string hurtSound;
//     public Slider healthBar;
//     public GameObject player;
//     Player pl;
//     Animator anim;
//     bool isGameOver = false; // Lisää tämä muuttuja

    
//     public void Start()
//     {
//         pl = player.GetComponent<Player>();
//         pl.health = pl.maxHealth;
//         healthBar.maxValue = pl.maxHealth;
//         healthBar.value = pl.health;
//         //anim = GetComponentInChildren<Animator>();
//     }

//     public void TakeDamage(float damage)
//     {
//         if (player != null && pl.health > 0) {
        
//         pl.health -= damage;
//         healthBar.value = pl.health;

//         AudioManager.instance.Play(hurtSound, this.gameObject);
//         }


//         if (pl.health <= 0) 
//         {
//             healthBar.value = pl.health;
//             // isGameOver = true;
//             anim.SetTrigger("dying");
//             // StartCoroutine(GameOverAfterDelay(5f));
//             //GameOver();
//         }
//     }

//     // IEnumerator GameOverAfterDelay(float delay)
//     // {
//     //     // Pysäytetään pelaajan liikkuminen asettamalla Rigidbody pois päältä
//     //     Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
//     //     if (playerRigidbody != null)
//     //     {
//     //         playerRigidbody.velocity = Vector3.zero;
//     //         playerRigidbody.angularVelocity = Vector3.zero;
//     //         playerRigidbody.isKinematic = true;
//     //     }

//     //     yield return new WaitForSeconds(delay); // Odota annettu aika
//     //     GameOver(); // Kutsu GameOver-metodia
//     // }
    
//     // public void Heal(int amount)
//     // {
//     //     if(player !=null && health < maxHealth){
//     //     health += amount;


//     //     if (health > maxHealth)
//     //     {
//     //         health = maxHealth;
//     //     }
//     //     }
//     // }

//     void GameOver()
//     {       
//         SceneManager.LoadScene("GameOver");
//     }

// }
