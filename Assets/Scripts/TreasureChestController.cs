using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestController : Interactable {
	Animator animator;
	bool open;

	public override void Setup(){
		promptText = "Open";
	}

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

    private void openAndShowItem() {
		open = true;
        animator.SetTrigger("open");

        Invoke("showMessage", 1f);
    }

    private void showMessage () {
        var message = ModalDialog.Create("You found *potion*!");
        message.SetActive(true);
    }
}
