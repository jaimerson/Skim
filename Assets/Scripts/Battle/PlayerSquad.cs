using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSquad : MonoBehaviour {

	public List<Character> characters;
	private Transform playerSquadPanel;

	// Use this for initialization
	void Awake () {
		this.playerSquadPanel = transform.Find("PlayerSquadPanel");
	}

	public void AddCharacter(Character character){
		this.characters.Add(character);
		GameObject panel = CreateActionPanel();
		panel.transform.SetParent(playerSquadPanel);
		CharacterActionPanel panelScript = panel.transform.GetComponent<CharacterActionPanel>();
		panelScript.SetCharacterName(character.name);
		panelScript.character = character;
	}
	
	// Update is called once per frame
	void Update () {

	}

	GameObject CreateActionPanel(){
		GameObject actionPanel = Instantiate(
			Resources.Load("Prefabs/Battle/CharacterActionPanel") as GameObject);
		return actionPanel;
	}
}
