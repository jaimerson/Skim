using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestController : InteractableItem {
	Animator animator;
	bool open;
    public Consumable item;
    Inventory inventory;


    public override void Setup(){
		promptText = "Open";
	}

    // Use this for initialization
    void Start () {
		animator = GetComponent<Animator>();
		open = false;
        inventory = Inventory.instance;
    }
	
	protected override bool canInteract(){
		return !open;
	}

	protected override void executeAction(){
		openAndShowItem();
        inventory.Add(item);
	}

    private void openAndShowItem()
    {
		open = true;
        animator.SetTrigger("open");
		var message = ModalDialog.Create("You found " + item.name);
		message.SetActive(true);
    }
}
