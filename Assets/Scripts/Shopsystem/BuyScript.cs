using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyScript : MonoBehaviour
{
    public GameObject shopUI;
    
    //Arrayt
    public int[] amt;
    public int[] cost;
    public int[] iconNum;
    public int[] inventoryItems;
    public Text[] itemAmountText;
    public Text currencyText;
    private Text compare;
    public bool store = false;
    private int max = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        max = itemAmountText.Length;
        currencyText.text = InventoryItems.gold.ToString();
    }

    public void BuyButton()
    {
        for(int i= 0; i < max; i++)
        {
            if(itemAmountText[i] == compare)
            {
                max = i;
                if(amt[i] > 0)
                {
                    if(store == true)
                    {
                        UpdateStoreAmt();
                    }
                    if(InventoryItems.gold >= cost[i])
                    {
                        if(inventoryItems[i] == 0)
                        {
                            InventoryItems.newIcon = iconNum[i];
                            InventoryItems.iconUpdate = true;

                        }
                        InventoryItems.gold -= cost[i];
                        if(store == true)
                        {
                            SetStoreAmt(i);
                        }
                    }
                }
            }
        }
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }

    void UpdateStoreAmt()
    {
        inventoryItems[0] = InventoryItems.healthPack; //tähän lisäilen kans itemin mukaan
        //inventoryItems[1] = inventoryItems.shotGun;

    }

    void SetStoreAmt(int item)
    {
        if(item == 0)
        {
            InventoryItems.healthPack++;

        }
        /*if(item == 1)
        {
            InventoryItem.uusItem++;
            
        }*/
        amt[item]--;
        itemAmountText[item].text = amt[item].ToString();
        currencyText.text = InventoryItems.gold.ToString();
        max = itemAmountText.Length;

    }

    public void HealthKit()
    {
        compare = itemAmountText[0];

    }
    /*public void Item2()
    {
        compare = itemAmountText[1];
        
    }*/

}
