using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public int number;

    
    public bool healthpacktestii = false;

    public bool pyssy = false;

    public bool pump_action_rifle = false; 

    public float rotationSpeed = 30.0f;

    private void OnTriggerEnter(Collider other)
    {
        
        
        if(other.CompareTag("Player"))
        {
            if(healthpacktestii == true)
            {
                if(InventoryItems.healthpacktestii == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.healthpacktestii++;
                
                Destroy(gameObject);
            }
                 
           
            else if(pyssy == true)
            {
                if(InventoryItems.pyssy == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.pyssy++;
                Destroy(gameObject);
            }
            else if(pump_action_rifle == true)
            {
                if(InventoryItems.pump_action_rifle == 0)
                {
                    DisplayIcons();
                }
                InventoryItems.pump_action_rifle++;
                Destroy(gameObject);
            }
            else
            {
                DisplayIcons();
                Destroy(gameObject);

            }

        }
    }
    void DisplayIcons()
    {
        InventoryItems.newIcon = number;
        InventoryItems.iconUpdate = true;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
