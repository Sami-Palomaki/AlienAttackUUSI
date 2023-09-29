using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFighter : MonoBehaviour
{
    public GameObject ProjectileFab;
    public Rigidbody r;
    public Transform projectileSpawnPoint; // Lisätään spawn-piste ammuksille

    // speed
    public float turnSpeed = 60f;
    public float boostSpeed = 45f;

    private void Start()
    {
        r = GetComponent<Rigidbody>();
        r.useGravity = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
        }
    }

    private void FixedUpdate()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Rotate");

        transform.Rotate(pitch, yaw, roll);
    }

    void Thrust()
    {
        float throttle = Input.GetAxis("Throttle");
        Vector3 thrustDirection = transform.forward * throttle;
        r.AddForce(thrustDirection * boostSpeed);
    }

    void FireProjectile()
    {
        if (ProjectileFab != null)
        {
            if (projectileSpawnPoint != null)
            {
                // Luo ammus ja aseta sen sijainti ja suunta spawn-pisteen perusteella
                GameObject projectile = Instantiate(ProjectileFab, projectileSpawnPoint.position, projectileSpawnPoint.rotation); // Käytetään projectileSpawnPoint.rotation
                
                // Laske etenemisnopeus (voit muuttaa ammuksen nopeutta tarpeen mukaan)
                float projectileSpeed = 10f; // Muuta tarvittaessa
                Vector3 projectileVelocity = projectile.transform.forward * projectileSpeed; // Käytetään projectile.transform.forward
                
                // Lisää nopeus ammukselle
                Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
                if (projectileRigidbody != null)
                {
                    projectileRigidbody.velocity = projectileVelocity;
                }
            }
            else
            {
                Debug.LogError("Projectile spawn point is not assigned!");
            }
        }
    }
}
