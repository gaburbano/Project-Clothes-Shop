using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeperInteract : Interactable
{
    public GameObject shop;
    
    public override void Interact(Player player)
    {
        if(!shop.activeSelf)
            shop.SetActive(!shop.activeSelf);
        Debug.Log("Shop Keeper Interact!");
    }
}
