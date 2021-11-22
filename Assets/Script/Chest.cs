using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable

{
    // chest from 8 hrs clip (Unused)
    public Sprite emptyChest;
    public int pesosAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant " + pesosAmount + " Pesos!");
        }
    }
}

