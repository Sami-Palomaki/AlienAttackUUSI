using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlockFighter : MonoBehaviour
{
    
    public Transform thisShip;

    public Rigidbody r;

    //speed
    public float turnSpeed = 60f;

    public float boostSpeed = 45f;



    private void Start()
    {
        r = GetComponent<Rigidbody>();
        r.useGravity = false;
    }

    //future variables
    
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
        
        thisShip.Rotate(pitch,yaw,roll);
    }
    
    void Thrust()
    {
        thisShip.position += thisShip.forward * boostSpeed * Time.deltaTime * Input.GetAxis("Throttle");
    }
    
    // Start is called before the first frame update


    // Update is called once per frame
    
}
