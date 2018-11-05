using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalDialog : MonoBehaviour {
	public Text text;
	public Text buttonText;
	public Button acceptButton;

	public Object prefab;

	public static GameObject Create(string message){
		Object prefab = Resources.Load("Assets/Prefabs/UI/ModalDialogueCanvas");
		GameObject dialog = Instantiate(prefab) as GameObject;
		dialog.GetComponent<ModalDialog>().text.text = message;
		return dialog;
	}

	// Use this for initialization
	void Start () {
		acceptButton.onClick.RemoveAllListeners();
		acceptButton.onClick.AddListener(Exit);
	}

	void setText(string newText){
		text.text = newText;
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
