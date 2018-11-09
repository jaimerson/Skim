using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPrompt : MonoBehaviour {

	public Text promptText;
	private static Object prefab;

	public void setText(string message) {
		promptText.text = message;
	}

	public static GameObject Create(string message){
		prefab = Resources.Load("Prefabs/UI/InteractPromptCanvas");
		GameObject dialog = Instantiate(prefab) as GameObject;
		dialog.GetComponent<InteractPrompt>().setText(message);
		return dialog;
	}
}
