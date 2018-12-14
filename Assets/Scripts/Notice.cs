using UnityEngine;

public class Notice : Interactable {

	public TextAsset textAsset;
	protected GameObject dialog;

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
}
