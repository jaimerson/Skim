﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerSquad : Squad {
	protected Transform squadPanel;

	// Use this for initialization
	void Awake () {
		this.squadPanel = transform.Find("PlayerSquadPanel");
	}

	protected override void onWaitForAction(){
		// For some reason this breaks enemy selection
		//selectAttackButton();
	}

	protected override void afterAddingCharacter(BattleCharacter character){
		setupActionPanel(character);
	}

	private void setupActionPanel(BattleCharacter bc){
		GameObject panel = CreateActionPanel();
		panel.transform.SetParent(squadPanel);
		CharacterActionPanel panelScript = panel.transform.GetComponent<CharacterActionPanel>();
		panelScript.SetCharacterName(bc.character.name);
		panelScript.character = bc;
	}

	private void selectAttackButton(){
        if (EventSystem.current != null){
            EventSystem.current.SetSelectedGameObject(GameObject.Find("Attack"));
        }
	}

	private GameObject CreateActionPanel(){
		GameObject actionPanel = Instantiate(
			Resources.Load("Prefabs/Battle/CharacterActionPanel") as GameObject);
		return actionPanel;
	}
}
