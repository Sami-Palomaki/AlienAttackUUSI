using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipShootController : MonoBehaviour
{
    public Transform gunTransform; // Aseman transform-komponentti, josta ammutaan
    public GameObject bulletPrefab; // Luotiprefab

    public float fireRate = 0.5f; // Ampumisen nopeus (kertaa sekunnissa)
    private float nextFireTime = 0f; // Aika seuraavaan laukaukseen

    private void Update()
    {
        // Tarkistetaan, onko pelaaja painanut ampumisnappia ja onko tarpeeksi aikaa kulunut edellisen laukauksen jälkeen
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Shoot(); // Ampuu
            nextFireTime = Time.time + 1f / fireRate; // Päivitetään seuraava laukauksen aika
        }
    }

    void Shoot()
    {
        // Luodaan luoti prefabista ja asetetaan sen sijainti ja suunta
        GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
        
        // Voit määrittää luodille nopeuden ja muita ominaisuuksia tässä

        // Tuhoaa luoti, jos se ei osu mihinkään tietyn ajan kuluttua, jotta se ei roiku ympärillä
        Destroy(bullet, 2.0f);
    }   
}
