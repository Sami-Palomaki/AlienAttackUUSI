using UnityEngine;
using System.Collections;
using System.Numerics;
using Unity.VisualScripting;

public class Projectile : MonoBehaviour {
    
    [SerializeField] [Range(10, 1000)] int _damage = 10;
    public int projectileSpeed = 120;
    private Transform myTransform;

    void Start()
    {
        myTransform = transform;

        Invoke("DestroyAmmo", 2.0f);
    }

    void Update()
    {
        myTransform.Translate(UnityEngine.Vector3.up * projectileSpeed * Time.deltaTime);  
        
        // Luodaan säde alkupisteestä eteenpäin
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Tarkistetaan, osuuko säde mihinkään Collideriin
        if (Physics.Raycast(ray, out hit))
        {
            IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();

            if (damageable != null)
            {
                UnityEngine.Vector3 hitPosition = hit.point;
                damageable.TakeDamage(_damage, hitPosition);
            }
            // Tässä voit tehdä jotain objektin kanssa, johon säde osui
            Debug.Log("Osui objektiin: " + hit.collider.name);
            Destroy(this.gameObject);
        }

    }

    private void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}