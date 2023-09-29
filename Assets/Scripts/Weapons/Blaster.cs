using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public float ammuksenNopeus = 5f;
    public GameObject _bulletPrefab; // Luotiprefab
    [SerializeField] Transform _muzzle;
    [SerializeField] [Range(0f, 5f)] float _coolDownTime = 0.25f;

    bool CanFire
    {
        get
        {
            _coolDown -= Time.deltaTime;
            return _coolDown <= 0f;
        }
    }

    float _coolDown;

    void Update()
    {
        if (CanFire && Input.GetMouseButton(0))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        Rigidbody bulletRigidbody = _bulletPrefab.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * ammuksenNopeus; // Aseta ammuksenNopeus haluamaksesi nopeudeksi

        _coolDown = _coolDownTime;
        Instantiate(_bulletPrefab, _muzzle.position, transform.rotation);
    }


}
