using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShootShotGun : MonoBehaviour

{
    
    public LayerMask collisionMask;
    //public GunType gunType;
    public float rpm;
   

    // Components:
    public Transform spawn;
    private LineRenderer tracer;
    public Transform shellEjectionPoint;
    public Rigidbody shell;
    //public Gun gunToCollect;
    public float damage = 3;

    public GameObject muzzleFlashPrefab;
    // System:

    [SerializeField] Transform muzzlePosition;
    private float secondsBetweenShots;
    private float nextPossibleShootTime;

    //[Header("AudioSource")]
    /*public string ammoPickUpSound;
    public string fireSound;
    public string unloadSound;
    public string loadSound;
    public string reloadSound;
    public string pickupSound;
    public string dropSound;*/
    public void Update()
    {
        //ControlMouse();
        //ControlWASD();
        
        // Gun Input
        //if (currentGun)
            //{
            //ShootShotGun shootShotGun = new ShootShotGun();
            if (Input.GetButtonDown("Shoot"))
            {
                
                Shoot();

                Quaternion muzzleRot = Quaternion.LookRotation(spawn.forward, Vector3.up);
// Luo muzzle flash prefab        
                GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, muzzlePosition.position, muzzleRot);

        // Tuhoa muzzle flash prefab tietyn ajan kuluttua        
                Destroy(muzzleFlash, 0.1f);
           
            }
    }
    
    
    
    public void Shoot()
    {
        
        
            // CALCULATE NEW VECTOR3, y=0


            Ray ray = new Ray(spawn.position, spawn.forward);
            RaycastHit hit;

            float shotDistance = 20;

            if (Physics.Raycast(ray, out hit, shotDistance, collisionMask))
            {
                shotDistance = hit.distance;

                if (hit.collider.GetComponent<Entity>())
                {
                    hit.collider.GetComponent<Entity>().TakeDamage(damage);
                }
            }

            nextPossibleShootTime = Time.time + secondsBetweenShots;

            //AudioManager.instance.Play(fireSound, this.gameObject);
            Debug.DrawRay(ray.origin, ray.direction * shotDistance, Color.red, 1);

            // Asettaa LineRendererin luodin radaksi
            if (tracer)
            {
                StartCoroutine("RenderTracer", ray.direction * shotDistance);
            }

            // Tuottaa hylsyjä ampuessa
            Rigidbody newShell = Instantiate(shell, shellEjectionPoint.position, Quaternion.identity) as Rigidbody;
            newShell.AddForce(shellEjectionPoint.forward * Random.Range(150f, 200f) + spawn.forward * Random.Range(-10f, 10f));
        
    }
    

    void Start()
    {
        secondsBetweenShots = 60/rpm;
        if (GetComponent<LineRenderer>())
        {
            tracer = GetComponent<LineRenderer>();
        }            
    }

    /*public void ShootContinuous()
    {
        if (gunType == GunType.Auto)
        {
            Shoot();
        }
    }*/

    // Kuinka nopeasti aseella voi ampua uudestaan
    public bool CanShoot()
    {
        bool canShoot = true;

        if (Time.time < nextPossibleShootTime)
        {
            canShoot = false;
        }

        return canShoot;
    }

    // LineRenderer luodin jälki
    IEnumerator RenderTracer(Vector3 hitPoint)
    {
        tracer.enabled = true;
        tracer.SetPosition(0, spawn.position);
        tracer.SetPosition(1, spawn.position + hitPoint);
        yield return null;
        tracer.enabled = false;
    }
}
