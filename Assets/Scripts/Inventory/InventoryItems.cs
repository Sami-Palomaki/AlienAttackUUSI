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
    public static int healthPack = 0;

    public static int pistol = 0;

    public static int shotgun = 0;

    public static int gold = 300;

    public Image[] UISlots;

    public Sprite[] magicIcons;

    public Sprite[] skillIcons;

    public KeyCode[] keys;

    public bool set = false;

    public bool setTwo = false;
    [HideInInspector]
    public int selected = 0;

    public int[] magicAttack;

    public GameObject[] magicParticles;
    //public WeaponSlot weaponSlot;
    public Transform weaponHolder;

    



    //private Weaponslot weaponslot;
    // Start is called before the first frame update
    void Start()
    {
        //playerObject = GameObject.Find("Pelaaja");
        //weaponSlot = playerObject.mixarig:Hips.mixamorig:Spine.mixamorig:Spine2.mixamorig:RightShoulder.mixamorig:RightArm.mixamorig:RightForeArm.mixamorig:RightHand.Weaponslot;
        inventoryMenu.SetActive(false);
        inventoryOpen.SetActive(false);
        inventoryClosed.SetActive(true);  
        max = emptySlots.Length;
        maxTwo = emptySlots.Length;    
        //temp
        healthPack = 0;
        pistol = 0;
        shotgun = 0;
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
        /*if(setTwo == true)
        {
           
            for(int i = 0; i < UISlots.Length; i++)
            {
                if(Input.GetKeyDown(keys[i]))
                {
                    setTwo = false;
                    UISlots[i].sprite = skillIcons[selected];
                    magicAttack[i] =  selected + 6;
                    //Removed(selected);
                }
            }
        }*/
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
                                
                        
                            
                                magicParticles[3].transform.SetParent(weaponHolder);
                                magicParticles[3].transform.localPosition = Vector3.zero;
                                magicParticles[3].transform.localRotation = Quaternion.identity;
                            

                                //magicParticles[3].transform.parent = weaponHolder;
                                //PlayerController.currentGun = Instantiate(magicParticles[3], weaponHolder.position, weaponHolder.rotation) as ShootShotGun;
                                //PlayerController.currentGun.transform.parent = weaponHolder;
                            }
                            
                            if(magicParticles[magicAttack[i]] == magicParticles[1])

                            {
                                

                                Debug.Log("pistooli");
                               
                                magicParticles[1].transform.SetParent(weaponHolder);
                                magicParticles[1].transform.localPosition = Vector3.zero;
                                magicParticles[1].transform.localRotation = Quaternion.identity;
                                
                                
                                //Instantiate(magicParticles[3]);
                            
                                //magicParticles[magicAttack[i]].transform.SetParent(weaponHolder);
                                //magicParticles[magicAttack[i]].transform.localPosition = Vector3.zero;
                                //magicParticles[magicAttack[i]].transform.localRotation = Quaternion.identity;
                                
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
