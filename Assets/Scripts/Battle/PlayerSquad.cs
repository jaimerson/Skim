using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlayerSquad : Squad {
	protected Transform squadPanel;

	// Use this for initialization
	void Awake () {
		this.squadPanel = transform.Find("PlayerSquadPanel");
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
	
	// Update is called once per frame
	void Update () {
		BattleQueue.waitingForPlayer = characters.All(x => x.waitingForAction);
	}

	GameObject CreateActionPanel(){
		GameObject actionPanel = Instantiate(
			Resources.Load("Prefabs/Battle/CharacterActionPanel") as GameObject);
		return actionPanel;
	}
}
