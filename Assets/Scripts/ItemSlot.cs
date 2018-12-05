﻿using UnityEngine.UI;
using UnityEngine;

public class ItemSlot : MonoBehaviour {

   
    private Item _item;

    [SerializeField] Image image;

    public Item Item
    {
        get { return _item;  }
        set
        {
            _item = value;
            if(_item == null)
            {
                image.enabled = false;
            } else
            {
                image.sprite = _item.icon;
                image.enabled = true;
            }
        }
    }

    private void OnValidate()
    {
        if (image == null)
            image = GetComponent<Image>();
    }
}
