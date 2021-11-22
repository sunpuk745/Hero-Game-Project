﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    // ตามชื่อ
    [Header("General Fields")]
    public List<GameObject> items= new List<GameObject>();
    public bool isOpen;
    [Header("UI Item Section")]
    public GameObject ui_Window;
    public Image[] items_images;
    [Header("UI item Description")]
    public GameObject ui_description_Window;
    public Image description_Image;
    public Text description_Title;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        ui_Window.SetActive(isOpen);

    }

    public void PickUp(GameObject item)
    {
        items.Add(item);

        Update_UI();
    }

    void Update_UI()
    {
        HideAll();
        for(int i=0;i<items.Count;i++)
        {
            items_images[i].sprite = items[i].GetComponent<SpriteRenderer>().sprite;
            items_images[i].gameObject.SetActive(true);
        }
    }

    void HideAll()
    {
        foreach (var i in items_images) { i.gameObject.SetActive(false); }
    }

    public void ShowDescription(int id)
    {
        description_Image.sprite = items_images[id].sprite;
        description_Title.text = items[id].name;
        description_Image.gameObject.SetActive(true);
        description_Title.gameObject.SetActive(true);
    }

    public void HideDescription()
    {
        description_Image.gameObject.SetActive(false);
        description_Title.gameObject.SetActive(false);
    }
}
