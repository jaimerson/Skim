using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestController : Interactable {
	Animator animator;
	bool open;

    // Use this for initialization
    void Start () {
		animator = GetComponent<Animator>();
		open = false;
	}
	
	protected override bool canInteract(){
		return !open;
	}

	protected override void executeAction(){
		openAndShowItem();
	}

    private void openAndShowItem()
    {
		open = true;
        animator.SetTrigger("open");
		var message = ModalDialog.Create("You found *potion*!");
		message.SetActive(true);
    }
}
