using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Message : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Text shopOwnerMessage;
    public Color32 messageOff;
    public Color32 messageOn;

    public GameObject shopUI;

    
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerController.canMove = false;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;

        PlayerController.canMove = true;

    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        shopOwnerMessage.text = "Welcome to my store " + SaveScript.pname + "! How may I help fellow star monger?";
    }

    public void Message1()
    {
        shopOwnerMessage.text = "Xyronia Prime is homeworld of those filthy bloodthirsty Xyronians.. Damn them!";
    }
    public void Message2()
    {
        shopOwnerMessage.text = "Here is some stuff that could help you slay those beasts!";

        shopUI.SetActive(true);
        shopUI.GetComponent<BuyScript>().UpdateGold();

    }

    void Update()
    {
        //johkin playercontrollerii jos liikeessä moving boolean
        /*if(PlayerController.canMove == true && Player.Controller.moving = true)
        {
            if (shopUI != null)
            {
                shopUI.SetActive(false);
            }
        }*/
    }
}
