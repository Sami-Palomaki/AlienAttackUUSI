using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Tarkistetaan, onko pelaaja koskenut collideriin
        if (other.CompareTag("TriggerZone"))
        {
            // Siirry seuraavaan skeneen
            SceneManager.LoadScene("Shop");
        }
    }
}
