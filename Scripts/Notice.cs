using UnityEngine;

public class Notice : InteractableItem {

	public TextAsset textAsset;
	private GameObject dialog;

	public override void Setup(){
		promptText = "Read";
	}

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
