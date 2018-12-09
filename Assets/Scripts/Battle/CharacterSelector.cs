using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour {
	public static List<BattleCharacter> options;
	public static BattleCharacter selected;

	public UnityEngine.Object pointerPrefab;
	private BattleCharacter selectedChar;
	private GameObject pointer;

	public static void SelectOne(List<BattleCharacter> characters){
		options = characters;
	}

	public static void Reset(){
		options = null;
		selected = null;
	}

	void Start(){
		this.pointer = Instantiate(pointerPrefab) as GameObject;
		pointer.SetActive(false);
//		pointer.transform.position = Vector3.zero;
	}
	
	void Update(){
		var options = CharacterSelector.options;
		if(options != null && options.Count > 0){
			if(selected == null){
				markSelected(options[0]);
			}
			if(Input.GetKeyDown(KeyCode.LeftArrow)){
				selectPrevious();
			}else if(Input.GetKeyDown(KeyCode.RightArrow)){
				selectNext();
			}else if(Input.GetKeyDown(KeyCode.Return)){

			}
		}
	}

	void selectNext(){

	}

	void selectPrevious(){

	}

	void markSelected(BattleCharacter character){
        selected = options[0];
		pointer.transform.SetParent(selected.gameObject.transform);
		pointer.transform.localPosition = Vector3.zero;
		pointer.SetActive(true);
	}
}
