using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractPrompt : MonoBehaviour {

	public Text promptText;
	private System.Action action;
	private static Object prefab;

	private static Object Prefab{
		get {
			if(prefab){
				return prefab;
			}else{
				prefab = Resources.Load("Prefabs/UI/InteractPromptCanvas");
				return prefab;
			}
		}
	}

	public void setText(string message) {
		promptText.text = message;
	}

	void OnMouseDown(){
		action.Invoke();
	}

	public static GameObject Create(string message, System.Action action){
		GameObject dialog = Instantiate(Prefab) as GameObject;
		InteractPrompt prompt = dialog.GetComponent<InteractPrompt>();
		prompt.setText(message);
		prompt.action = action;
		return dialog;
	}
}
