using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSquad : Squad {
	protected Transform squadPanel;

	// Use this for initialization
	void Awake () {
		this.squadPanel = transform.Find("PlayerSquadPanel");
	}

	protected override void afterAddingCharacter(Character character){
		setupActionPanel(character);
	}

	private void setupActionPanel(Character character){
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
