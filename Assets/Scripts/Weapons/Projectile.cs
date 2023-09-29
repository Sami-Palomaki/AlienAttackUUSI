// using System;
// using System.Collections;
// using System.Collections.Generic;
// using Unity.VisualScripting;
// using UnityEngine;

// public class Projectile : MonoBehaviour
// {

//     [SerializeField] [Range(5000f, 25000f)] 
//     float _launchForce = 10000f;
//     [SerializeField] [Range(10, 1000)] int _damage = 100;
//     [SerializeField] [Range(2f, 10f)] float _range = 5f;

//     bool OutOfFuel
//     {
//         get
//         {
//             _duration -= Time.deltaTime;
//             return _duration <= 0f;
//         }
//     }

//     Rigidbody _rigidBody;
//     float _duration;

//     void Awake()
//     {
//         _rigidBody = GetComponent<Rigidbody>();
//     }

//     void onEnable()
//     {
//         _rigidBody.AddForce(_launchForce * transform.forward);
//         _duration = _range;
//     }

//     void Update()
//     {
//         if (OutOfFuel) Destroy(gameObject);
//     }

//     void OnCollisionEnter(Collision collision)
//     {
//         Debug.Log("projectile collided with {collision.collider.name}");
//     }
// }


using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    
    public int projectileSpeed = 7;
    private Transform myTransform;

    void Start()
    {
        myTransform = transform;

        Invoke("DestroyAmmo", 2.0f);
    }

    void Update()
    {
        myTransform.Translate(Vector3.up * projectileSpeed * Time.deltaTime);    
    }

    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}