using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingDialog : MonoBehaviour {
	public Text text;
	public static GameObject Create(string message){
		UnityEngine.Object prefab = Resources.Load("Prefabs/UI/FadingDialogCanvas");
		GameObject dialog = Instantiate(prefab) as GameObject;
		dialog.GetComponent<FadingDialog>().setText(message);
		return dialog;
	}

	public void setText(string message) {
		text.text = message;
	}
}
