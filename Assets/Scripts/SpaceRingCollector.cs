using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpaceRingCollector : MonoBehaviour
{
    public TextMeshPro timeText; // Teksti, joka näyttää jäljellä olevan ajan
    public float startingTime = 15.0f; // Alkuaika sekunteina
    private float currentTime; // Jäljellä oleva aika


    void Start()
    {
        currentTime = startingTime;
        UpdateUI();
    }

    void Update()
    {
        currentTime -= Time.deltaTime; // Vähennä aikaa joka sekunti

        if (currentTime <= 0)
        {
            // Peli päättyy ajan loppuessa
            Debug.Log("Peli päättyi!");
            // Voit lisätä tähän pelin päättymiseen liittyviä toimintoja.
        }

        UpdateUI();
    }

    // Tätä kutsutaan, kun pelaaja lentää renkaan läpi
    public void CollectRing()
    {
        currentTime += 10.0f; // Lisää aikaa 10 sekuntia, kun renkaan läpi lentäminen onnistuu
        UpdateUI();
    }

    void UpdateUI()
    {
        timeText.text = "Aikaa jäljellä: " + currentTime.ToString("F1") + " s";
    }
}
