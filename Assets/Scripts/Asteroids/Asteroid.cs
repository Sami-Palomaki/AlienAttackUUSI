using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamageable
{
    [SerializeField] private FracturedAsteroid _fracturedAsteroidPrefab;
    [SerializeField] private Detonator _explosionPrefab;
    [SerializeField] private int asteroidHealth = 30;
    [SerializeField] private float minSpeed = 3f; // Miniminopeus
    [SerializeField] private float maxSpeed = 8f; // Maksiminopeus

    private Transform _transform;
    private Vector3 movementDirection;
    private float currentSpeed;

    private void Awake()
    {
        _transform = transform;
        // Alusta satunnainen liikkumissuunta ja nopeus
        InitializeMovement();
    }

    private void Update()
    {
        // Liikuta asteroidia eteenpäin sen liikkumissuuntaan
        _transform.Translate(movementDirection * currentSpeed * Time.deltaTime);

        // Tarkista, jos asteroidi on mennyt kauas pois näytöltä, ja tuhoa se tarvittaessa
        // if (!IsAsteroidOnScreen())
        // {
        //     Destroy(gameObject);
        // }
    }

    private void InitializeMovement()
    {
        // Arvo satunnainen liikkumissuunta
        movementDirection = Random.insideUnitSphere.normalized;

        // Arvo satunnainen nopeus välillä minSpeed ja maxSpeed
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }

    public void TakeDamage(int damage, Vector3 hitPosition)
    {
        asteroidHealth -= damage;

        if (asteroidHealth <= 0)
        {
            FractureAsteroid(hitPosition);
        }
    }

    private void FractureAsteroid(Vector3 hitPosition)
    {
        if (_explosionPrefab != null)
        {
            Instantiate(_explosionPrefab, hitPosition, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private bool IsAsteroidOnScreen()
    {
        // Tarkista, onko asteroidi edelleen näytöllä
        Vector3 screenPos = Camera.main.WorldToScreenPoint(_transform.position);
        return screenPos.x > 0 && screenPos.x < Screen.width &&
               screenPos.y > 0 && screenPos.y < Screen.height;
    }
}
