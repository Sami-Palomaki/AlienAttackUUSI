using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{


    public float rotationSpeed = 30.0f; // pyörimisnopeus

    public int goldAmt = 10;
    void Update()
    {
        // up eli y-akselin kautta pyörii
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            InventoryItems.gold += goldAmt;
            Destroy(gameObject);
        }
    }
}
