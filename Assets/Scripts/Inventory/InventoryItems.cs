using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItems : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject inventoryOpen;
    public GameObject inventoryClosed;

    public GameObject messageBox;
    
    public Image[] emptySlots;
    public Sprite[] icons;

    public Sprite emptyIcon;

    
    public static int newIcon = 0;
    public static bool iconUpdate = false;

    private int max;
    
    private int maxTwo;

    public static int heal = 0;
    public static int healthpacktestii = 0;

    public static int pyssy = 0;

    public static int pump_action_rifle = 0;

    public static int gold = 300;

    public Image[] UISlots;

    public Sprite[] magicIcons;

    public Sprite[] skiIcons;

    public KeyCode[] keys;

    public bool set = false;
    
    public bool setTwo = false;
    [HideInInspector]
    public int selected = 0;
    public int[] magicAttack;

    public GameObject[] magicParticles;
    //public WeaponSlot weaponSlot;
    public Transform weaponHolder;

    public Transform effectHolder;
    //shotgunin ja pistolin placeus koordinaatit
    float desiredXRotation = -8.73f;  // Replace with your desired x rotation in degrees
    float desiredYRotation = 22.34f;  // Replace with your desired y rotation in degrees
    float desiredZRotation = 98.66f; 

    float XPosition = 0.06f;  // Replace with your desired x position
    float YPosition = 0.05f;   // Replace with your desired y position
    float ZPosition = -0.03f;
    //private Weaponslot weaponslot;
    // Start is called before the first frame update

    public string entry;
    public string[] items;

    public int currentID = 0;
    public int checkAmt = 0;
    //private int maxTwo;
    //private int maxThree;
    void Start()
    {
        //playerObject = GameObject.Find("Pelaaja");
        //weaponSlot = playerObject.mixarig:Hips.mixamorig:Spine.mixamorig:Spine2.mixamorig:RightShoulder.mixamorig:RightArm.mixamorig:RightForeArm.mixamorig:RightHand.Weaponslot;
        inventoryMenu.SetActive(false);
        inventoryOpen.SetActive(false);
        inventoryClosed.SetActive(true);  
        max = emptySlots.Length;
        //maxTwo = items.Length;   
        //maxThree =  emptySlots.Length; 
        //temp
        healthpacktestii = 0;
        pyssy = 0;
        pump_action_rifle = 0;
        heal = 0;
    }

    // Update is called once per frame
    
    /*void Empty()
    {
        
        
        {
            // Get the first child (assuming only one weapon).
            
            EmptySlot(transform.GetChild(0).SetParent(null));
            // Detach the weapon from the weapon slot.
          
        }
    }*/
    
    void Update()
    {
        if(iconUpdate == true)
        {
            for(int i = 0; i < max; i++)
            {
                if(emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;
                }
            }
            StartCoroutine(Reset());
        }
        //if(Input.anyKey)
        //{
        //    set = true;
        //}
        if(set == true)
        {
           
            for(int i = 0; i < UISlots.Length; i++)
            {
                if(Input.GetKeyDown(keys[i]))
                {
                    
                    set = false;
                    UISlots[i].sprite = magicIcons[selected];
                    magicAttack[i] =  selected;
                    //Removed(selected);
                }
            }
        }
        if(setTwo == true)
        {
           
            for(int i = 0; i < UISlots.Length; i++)
            {
                if(Input.GetKeyDown(keys[i]))
                {
                    setTwo = false;
                    UISlots[i].sprite = magicIcons[selected];
                    Debug.Log(UISlots[i]);
                    Debug.Log(magicIcons[selected]);
                    magicAttack[i] =  selected = 6;
                    //Removed(selected);
                }
            }
        }
        if(Input.anyKey && Time.timeScale == 1)
        {
            for(int i = 0; i < UISlots.Length; i++)
            {
                if(Input.GetKeyDown(keys[i]))
                {
                   if(UISlots[i].sprite != emptyIcon)
                   {
                        //if(UISlots[i].sprite == magicParticles[magicAttack[i]])
                            
                            //{   

                            
                            if(magicParticles[magicAttack[i]] == magicParticles[3])
                            {
                                Debug.Log("shotgun");
                                
                                
                                //
                                
                                magicParticles[1].transform.SetParent(null);
                            
                                magicParticles[3].transform.SetParent(weaponHolder);
                                magicParticles[3].transform.localPosition = Vector3.zero;
                                magicParticles[3].transform.localRotation = Quaternion.identity;
                            

                                //magicParticles[3].transform.parent = weaponHolder;
                                //PlayerController.currentGun = Instantiate(magicParticles[3], weaponHolder.position, weaponHolder.rotation) as ShootShotGun;
                                //PlayerController.currentGun.transform.parent = weaponHolder;
                            }
                            
                            else if(magicParticles[magicAttack[i]] == magicParticles[1])

                            {
                                magicParticles[3].transform.SetParent(null);

                                Debug.Log("pistooli");
                               
                                magicParticles[1].transform.SetParent(weaponHolder);
                                Vector3 currentPosition = magicParticles[3].transform.localPosition;
                                Quaternion currentRotation = magicParticles[1].transform.localRotation;
                                Quaternion newRotation = Quaternion.Euler(desiredXRotation, desiredYRotation, desiredZRotation);
                                //magicParticles[1].transform.localRotation = Quaternion.identity;
                                Vector3 newPosition = new Vector3(XPosition, YPosition, ZPosition);
                                magicParticles[1].transform.localRotation = newRotation;
                                magicParticles[1].transform.localPosition = newPosition;
                                
                                //Instantiate(magicParticles[3]);
                            
                                //magicParticles[magicAttack[i]].transform.SetParent(weaponHolder);
                                //magicParticles[magicAttack[i]].transform.localPosition = Vector3.zero;
                                //magicParticles[magicAttack[i]].transform.localRotation = Quaternion.identity;
                                
                            }

                            else if(magicParticles[magicAttack[i]] == magicParticles[2])

                            {
                                Debug.Log("healthkitti");
                                magicParticles[2].transform.SetParent(weaponHolder);
                                magicParticles[2].transform.localPosition = Vector3.zero;
                                magicParticles[2].transform.localRotation = Quaternion.identity;
                                /*Vector3 currentPosition = magicParticles[2].transform.localPosition;
                                Quaternion currentRotation = magicParticles[2].transform.localRotation;
                                Quaternion newRotation = Quaternion.Euler(desiredXRotation, desiredYRotation, desiredZRotation);
                                Vector3 newPosition = new Vector3(XPosition, YPosition, ZPosition);
                                
                                magicParticles[2].transform.localRotation = newRotation;
                                magicParticles[2].transform.localPosition = newPosition;*/
                                
                               
                                Instantiate(magicParticles[2]);
                                

                            }
                            //magicParticles[3].transform.parent = weaponHolder;
                                //PlayerController.currentGun = Instantiate(magicParticles[3], weaponHolder.position, weaponHolder.rotation) as ShootShotGun;
                                //PlayerController.currentGun.transform.parent = weaponHolder;
                            //}
                            //magicParticles[3].transform.SetParent(weaponHolder);

                            //if(magicParticles(i) == 1 || magicParticles(i) == 3)
                            //{
                            //    magicParticles[magicAttack[i]].transform.SetParent(weaponHolder);
                            //}
                            //else
                            //
                                //Instantiate(magicParticles[magicAttack[i]], weaponHolder.transform.position, weaponHolder.transform.rotation);
                            
                        
                   }
                }
            }
        }
    }

    /*public void CheckStatistics()
    {
        for(int i = 0; i < maxTwo; i++)
        {
            if(i = currentID)
            {
                maxTwo = i;
                checkAmt = System.Convert.ToInt32(typeof(InventoryItems).GetField(entry).GetValue(null));
                checkAmt--;
                typeof(InventoryItems).GetField(entry).SetValue(null, checkAmt);
                if(checkAmt == 0);
                {
                    RemoveIcon(i);
                }
                

            }
            maxTwo = items.Length;
        }
    }

    public void RemoveIcon(int iconType)
    {
        for(int i = 0; i < maxThree;i++)
        {
            if(emptySlots[i].sprite == icons[iconType])
            {
                maxThree = i;
                emptySlots[i].sprite = icons[0];
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        maxThree = emptySlots.Length;
    }*/
    public void OpenMenu()
    {
        messageBox.SetActive(false);
        inventoryMenu.SetActive(true);
        inventoryOpen.SetActive(true);
        inventoryClosed.SetActive(false);
        Time.timeScale = 0f;

    }
    public void ClosedMenu()
    {
        inventoryMenu.SetActive(false);
        inventoryOpen.SetActive(false);
        inventoryClosed.SetActive(true);
        Time.timeScale = 1f;
        
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.01f); //tää jotenkin vaikuttaa tohon itemien poimintaan, kauan venaa ennenkö vetää updaten läpi tms tutorialis settaaa 0.1f
        
        iconUpdate = false;
        max = emptySlots.Length;
    }
    public void Removed(int index)
    {
        for(int i = 0; i < maxTwo;i++)
        {
            if(emptySlots[i].sprite == icons[index])
            {
                maxTwo = i;
                emptySlots[i].sprite = emptyIcon;
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        maxTwo = emptySlots.Length;
    }

}
