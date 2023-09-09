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
    public static int healthPack = 0;

    public static int pistol = 0;

    public static int shotgun = 0;

    public static int gold = 300;

    public Image[] UISlots;

    public Sprite[] magicIcons;

    public KeyCode[] keys;

    public bool set = false;
    [HideInInspector]
    public int selected = 0;

    public int[] magicAttack;

    public GameObject[] usables;


    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        inventoryOpen.SetActive(false);
        inventoryClosed.SetActive(true);  
        max = emptySlots.Length;
        maxTwo = emptySlots.Length;    
        //temp
        healthPack = 0;
        pistol = 0;
        shotgun = 0;
    }

    // Update is called once per frame
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
                    Removed(selected);
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
