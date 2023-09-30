using UnityEngine;

public class RingController : MonoBehaviour
{
    private SpaceRingCollector gameController; // Viittaus pelin ohjausskriptiin

    private void Start()
    {
        // Hae viittaus pelin ohjausskriptiin, joka sisältää ajan ja renkaiden hallinnan
        gameController = GameObject.FindWithTag("GameController").GetComponent<SpaceRingCollector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("tuleeko OnTriggerEnteriin ollenkaan?");
        // Tarkista, onko pelaaja törmännyt renkaaseen
        if (other.CompareTag("Player"))
        {
            // Lisää aikaa pelaajalle ja tuhoa renkaan GameObject
            gameController.CollectRing();
        }
    }
}
