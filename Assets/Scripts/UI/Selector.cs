using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selector : MonoBehaviour {
	public UnityEngine.Object ButtonPrefab;
	public GameObject buttonContainer;
	public List<IConsumable> options;

	public IConsumable selected;
	public bool selectionEnded;

	public static Selector Create(List<IConsumable> options){
		UnityEngine.Object prefab = Resources.Load("Prefabs/UI/Selector");
		GameObject instance = Instantiate(prefab) as GameObject;
		Selector selector = instance.GetComponent<Selector>();
		selector.options = options;
		return selector;
	}

	// Use this for initialization
	void Start () {
		foreach(IConsumable option in options){
			GameObject button = createButton();
			button.GetComponentInChildren<Text>().text = option.getName();
			button.GetComponent<Button>().onClick.AddListener(() => setSelected(option));
		}	
	}

	private GameObject createButton(){
        GameObject button = Instantiate(ButtonPrefab) as GameObject;
        button.transform.SetParent(buttonContainer.transform);
        return button;
	}

	private void setSelected(IConsumable option){
		this.selected = option;
		this.selectionEnded = true;
	}
}
