using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject hintBox;
    public Text message;

    private Vector3 screenPoint;

    private bool displaying = true;
    private bool overIcon = false;

    public int objectType = 0;

    public GameObject inventoryObject;
    public bool inventoryUsables = false;

    public bool skills = false; 

    public void OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;
        if(displaying == true)
        {
            hintBox.SetActive(true);
            screenPoint.x = Input.mousePosition.x; //+ //400;
            screenPoint.y = Input.mousePosition.y - 300;
            screenPoint.z = 1f;
            hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            MessageDisplay();
        }   
    }
    public void OnPointerExit(PointerEventData eventData)

    {
        overIcon = false;
        hintBox.SetActive(false);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        hintBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(overIcon == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                displaying = false;
                hintBox.SetActive(false);
                if(inventoryUsables == true)
                {
                
                
                inventoryObject.GetComponent<InventoryItems>().selected = objectType;
                inventoryObject.GetComponent<InventoryItems>().set = true;
                }
                if(skills == true)
                {
                
                
                inventoryObject.GetComponent<InventoryItems>().selected = objectType;
                inventoryObject.GetComponent<InventoryItems>().setTwo = true;
                }

            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            displaying = true;
            hintBox.SetActive(false);

        }    
        
    }
    void MessageDisplay()
    {
        if(objectType == 0)
        {
            message.text = "empty";           
        }
        if(objectType == 1)
        {
            message.text = /*InventoryItems.pyssy.ToString() +*/ "Basic pistol designed for Alien slaying";
        }

        if(objectType == 2)
        {
            message.text = InventoryItems.healthpacktestii.ToString() +  "Health kits that heals you once whenever you want 666 HPs";
        }
        if(objectType == 3)
        {
            message.text = /*InventoryItems.pump_action_rifle.ToString() +*/ "Shotgun that makes shitloads of damage";
        }
        
        if(objectType == 33)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Heal: Heals hero based on wisdom stat";
        }
        if(objectType == 33)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Energy Dash: Quick dash throughh enemies partly invulnerable";  
        }
        if(objectType == 34)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Nova Overdrive: Player channels power to gauntlets and releases devastating blow";
        }
        if(objectType == 35)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Astral Projection: Temporal project of holographic image of hero that distract enemies";
        }
        if(objectType == 36)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Quantum Barrier: Hero deploys a deployable energy barrier that blocks incoming projectiles and enemy fire.";
        }
        if(objectType == 37)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Solar Flare: Hero charges up his gauntlets to release a blinding burst of solar energy, stunning enemies and leaving them vulnerablefor a short period.";
        }
        if(objectType == 38)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Singularity Grenade: Hero throws a grenade that creates a miniature singularity upon impact. Enemies caught within are immobilized and take increased damage.";


        }
        if(objectType == 39)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Chrono-Strike: Hero performs a precision strike, targeting an enemy's weak point and dealing massive damage. It's making it a high-risk, high-reward ability.";
        }
        if(objectType == 40)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Ethereal Cloak: Hero becomes temporarily invisible, allowing him to move undetected among enemies. While cloaked, he can perform stealth takedowns and avoid enemy fire.";
        }
        if(objectType == 41)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "Cosmic Surge: Hero taps into cosmic energy, increasing his movement speed, attack rate, and damage output for a short duration.";
        }
        if(objectType == 42)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "This is Pump-action shotgun that makes shitloads of damage";
        }
        if(objectType == 43)
        {
            message.text = /*InventoryItems.shotgun.ToString() + */ "This is Pump-action shotgun that makes shitloads of damage";
        }
        /*if(objectType == 44)
        {
            message.text = InventoryItems.shotgun.ToString() +  "This is Pump-action shotgun that makes shitloads of damage";
        }
        if(objectType == 45)
        {
            message.text = InventoryItems.shotgun.ToString() +  "This is Pump-action shotgun that makes shitloads of damage";
        }
        if(objectType == 46)
        {
            message.text = InventoryItems.shotgun.ToString() + "This is Pump-action shotgun that makes shitloads of damage";
        }
        if(objectType == 47)
        {
            message.text = InventoryItems.shotgun.ToString() +  "This is Pump-action shotgun that makes shitloads of damage";
        }
        if(objectType == 48)
        {
            message.text = InventoryItems.shotgun.ToString() +  "This is Pump-action shotgun that makes shitloads of damage";*/
        
    
    }
}
