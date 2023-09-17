using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayGold : MonoBehaviour


{
    
    public Text goldText;
    // Start is called before the first frame update
    void Start()
    {
        goldText.text = InventoryItems.gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = InventoryItems.gold.ToString();
    }

}
