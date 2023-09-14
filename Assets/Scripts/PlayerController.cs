                                                            using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Handling
    public float rotationSpeed = 450;
    public float walkSpeed = 5;
    public float runSpeed = 8;
    private float acceleration = 5;

    // System
    private Quaternion targetRotation;
    private Vector3 currentVelocityMod;

    // Components
    public GameObject inventoryCanvas;
    public Transform handHold;
    public Gun[] guns;
    private Gun collectedGun;
    private bool isInventoryOpen = false;
    
    private Gun currentGun;
    private CharacterController controller;
    private Camera cam;
    private Animator animator; // Lisätty Animator-komponentti
    public static bool canMove = true;
    public bool isDead;




    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
        animator = GetComponent<Animator>(); // Haetaan Animator-komponentti

        EquipGun(0);
    }


    void Update()
    {
        if (!isDead)
        {
            ControlMouse();
            //ControlWASD();
        }
        
        // Gun Input
        if (collectedGun)
        {
           
            if (Input.GetButtonDown("Shoot"))
            {
                if(canMove == true)
                {
                    currentGun.Shoot();
                }
            }
            else if (Input.GetButton("Shoot"))
            {
                if(canMove == true)
                {
                    currentGun.ShootContinuous();
                }   
            }

            // Tarkista, onko pelaaja painanut I-näppäintä
            if (Input.GetKeyDown(KeyCode.I))
            {
                // Vaihda InventoryCanvasin tilaa käyttämällä aktiivisuutta
                isInventoryOpen = !isInventoryOpen;
                inventoryCanvas.SetActive(isInventoryOpen);

                // Pysäytä tai jatka pelin aikaa sen mukaan, onko InventoryCanvas päällä
                Time.timeScale = isInventoryOpen ? 0f : 1f;
            }
        }

        for (int i = 0; i < guns.Length; i++)
        {
            if (Input.GetKeyDown((i+1) + "") || Input.GetKeyDown("[" + (i+1) + "]"))
            {
                EquipGun(i);
                break;
            }
        }
    }

    void EquipGun(int i)
    {
        if (collectedGun)
        {

            if (currentGun)
            {
                Destroy(currentGun.gameObject);
            }

            currentGun = Instantiate(guns[i], handHold.position, handHold.rotation) as Gun;
            currentGun.transform.parent = handHold;
            animator.SetFloat("Weapon ID", currentGun.gunID);
        }
    }

    // Metodi aseen lisäämiseksi listaan
    public void AddCollectedGun(Gun newGun)
    {
        collectedGun = newGun;

        // Lisää uusi ase guns-listaan
        if (collectedGun != null)
        {
            int newLength = guns.Length + 1;
            Array.Resize(ref guns, newLength);
            guns[newLength - 1] = collectedGun;
        }
    }

    void ControlMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
        targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0, transform.position.z));
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        currentVelocityMod = Vector3.MoveTowards(currentVelocityMod, input, acceleration * Time.deltaTime);
        Vector3 motion = currentVelocityMod;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1)?.7f:1;
        motion *= (Input.GetButton("Run"))?runSpeed:walkSpeed;
        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime);
        
        animator.SetFloat("Speed", Mathf.Sqrt(motion.x * motion.x + motion.z * motion.z));
    }

    void ControlWASD()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (input != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }

        currentVelocityMod = Vector3.MoveTowards(currentVelocityMod, input, acceleration * Time.deltaTime);
        Vector3 motion = currentVelocityMod;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1)?.7f:1;
        motion *= (Input.GetButton("Run"))?runSpeed:walkSpeed;
        motion += Vector3.up * -8;

        controller.Move(motion * Time.deltaTime);

        animator.SetFloat("Speed", Mathf.Sqrt(motion.x * motion.x + motion.z * motion.z));
    }
}
