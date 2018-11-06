using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalDialog : MonoBehaviour {
	public Text text;
	public Text buttonText;
	public Button acceptButton;

	private static Object prefab;

	public void setText(string message) {
		text.text = message;
	}

	public static GameObject Create(string message){
		prefab = Resources.Load("Prefabs/UI/ModalDialogueCanvas");
		GameObject dialog = Instantiate(prefab) as GameObject;
		dialog.GetComponent<ModalDialog>().setText(message);
		return dialog;
	}

	// Use this for initialization
	void Start () {
		acceptButton.onClick.RemoveAllListeners();
		acceptButton.onClick.AddListener(Exit);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("return")){
			Exit();
		}
	}

	void Exit(){
		Destroy(gameObject);
	}
}
