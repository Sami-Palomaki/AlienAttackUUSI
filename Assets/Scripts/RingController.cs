using UnityEngine;

public class RingController : MonoBehaviour
{
    private SpaceRingCollector gc; // Viittaus pelin ohjausskriptiin

    private void Start()
    {
        // Hae viittaus pelin ohjausskriptiin, joka sisältää ajan ja renkaiden hallinnan
        gc = GameObject.FindWithTag("GameController").GetComponent<SpaceRingCollector>();

    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("tuleeko OnTriggerEnteriin ollenkaan?");
        // Tarkista, onko pelaaja törmännyt renkaaseen
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ei toimi!");
            // Lisää aikaa pelaajalle ja tuhoa renkaan GameObject
            gc.CollectRing();
        }
    }
}
