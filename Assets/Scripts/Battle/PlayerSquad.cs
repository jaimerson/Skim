using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSquad : Squad {

	// Use this for initialization
	void Awake () {
		this.squadPanel = transform.Find("PlayerSquadPanel");
	}

	public void AddCharacter(Character character){
		addCharacterAndSetupActionPanel(character);
	}

	private void addCharacterAndSetupActionPanel(Character character){
		this.characters.Add(character);
		GameObject panel = CreateActionPanel();
		panel.transform.SetParent(squadPanel);
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
