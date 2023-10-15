using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFighter : MonoBehaviour
{
    public GameObject ProjectileFab;
    Rigidbody r;
    public Transform projectileSpawnPoint; // Lisätään spawn-piste ammuksille
    public ParticleSystem engineFlames;

    // speed
    public float turnSpeed;
    public float boostSpeed;
    private float yaw, roll, pitch, thrust;

    private void Start()
    {
        r = GetComponent<Rigidbody>();
        r.useGravity = false;
    }

    void Update()
    {
        GetInputs();
        
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
        Quaternion rotation = Quaternion.Euler(pitch, yaw, roll);
        //r.MoveRotation(Quaternion.Slerp(r.rotation, r.rotation *= rotation, Time.deltaTime * 10f));
        //r.MoveRotation(r.rotation *= rotation);
        //r.MovePosition(transform.position += (transform.forward * thrust));
        r.AddRelativeForce(Vector3.forward * thrust, ForceMode.Impulse);
        Debug.Log(Vector3.forward * thrust);
    }

    void GetInputs()
    {
        thrust = boostSpeed * Input.GetAxis("Throttle");
        yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        roll = turnSpeed * Time.deltaTime * Input.GetAxis("Rotate");
        //Debug.Log(thrust);
    }

     void Thrust()
    {
        
        //r.velocity = new Vector3(yaw, pitch, thrust);
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