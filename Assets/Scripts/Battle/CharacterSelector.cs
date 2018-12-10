using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour {
	public static List<BattleCharacter> options;
	public static BattleCharacter selected;
	public static bool selectionConfirmed = false;

	public UnityEngine.Object pointerPrefab;
	private BattleCharacter selectedChar;
	private GameObject pointer;

	public static void SelectOne(List<BattleCharacter> characters){
		options = characters;
	}

	public static void Reset(){
		options = null;
		selected = null;
		selectionConfirmed = false;
	}

	void Start(){
		this.pointer = Instantiate(pointerPrefab) as GameObject;
		pointer.SetActive(false);
		pointer.transform.position = Vector3.zero;
	}
	
	void Update(){
		if(options != null && options.Count > 0){
			if(selected == null){
				markSelected(options[0]);
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				selectPrevious();
			}else if(Input.GetKeyDown(KeyCode.RightArrow)){
				selectNext();
			}else if(Input.GetButtonDown("Submit")){
				selectionConfirmed = true;
				pointer.SetActive(false);
			}
		}
	}

	void selectNext(){
		Debug.Log(options);
		int selectedIndex = options.IndexOf(selected);
		if(selectedIndex == options.Count - 1){
			markSelected(options[0]);
		}else{
			markSelected(options[selectedIndex + 1]);
		}
	}

	void selectPrevious(){
		int selectedIndex = options.IndexOf(selected);
		if(selectedIndex == 0){
			markSelected(options[options.Count - 1]);
		}else{
			markSelected(options[selectedIndex - 1]);
		}
	}

	void markSelected(BattleCharacter character){
        selected = character;
		pointer.transform.SetParent(selected.gameObject.transform);
		pointer.transform.localPosition = Vector3.zero;
		pointer.SetActive(true);
	}
}
