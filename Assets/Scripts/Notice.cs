using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice : Interactable {

	public TextAsset textAsset;
	private GameObject dialog;

	protected override void executeAction(){
		dialog = ModalDialog.Create(textAsset.text);
		dialog.SetActive(true);
	}

	protected override bool canInteract(){
		return dialog == null || !dialog.activeSelf;
	}

	protected override void OnEnterInteractionPossible(){
		gameObject.GetComponent<Light>().enabled = true;
	}

	protected override void OnExitInteractionPossible(){
		gameObject.GetComponent<Light>().enabled = false;
	}
}
