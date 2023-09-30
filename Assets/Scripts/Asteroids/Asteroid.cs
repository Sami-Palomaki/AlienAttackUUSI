using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour, IDamageable
{
    [SerializeField] private FracturedAsteroid _fracturedAsteroidPrefab;
    [SerializeField] private Detonator _explosionPrefab;
    [SerializeField] private int asteroidHealth = 30;
        
    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
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

        if (_fracturedAsteroidPrefab != null)
        {
            Instantiate(_fracturedAsteroidPrefab, _transform.position, _transform.rotation);
        }

        if (_explosionPrefab != null)
        {
            Instantiate(_explosionPrefab, hitPosition, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}

