using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterActionPanel : MonoBehaviour {
	public GameObject actions;
	public GameObject stats;
	public Text characterName;

	public bool waitingPlayerAction;
	public Character character;

	public Button attackButton, itemButton, spellButton;

	public void SetCharacterName(string name){
		this.characterName.text = name;
	}

	// Use this for initialization
	void Start () {
		this.attackButton.onClick.AddListener(attack);
		this.spellButton.onClick.AddListener(spell);
		this.itemButton.onClick.AddListener(item);
		this.actions.SetActive(!waitingPlayerAction);
		this.stats.SetActive(waitingPlayerAction);
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void spell(){
		BattleQueue.Enqueue(
			new BattleAction {
				performer = this.character,
				message = string.Format("{0} casts spell", this.character.name),
				action=Character.Spell,
				target=null
			}
		);
	}

	private void item(){
		BattleQueue.Enqueue(
			new BattleAction {
				performer = this.character,
				message = string.Format("{0} uses item", this.character.name),
				action=Character.Item,
				target=null
			}
		);
	}

	private void attack(){
		Character victim = BattleQueue.randomEnemy();
		BattleQueue.Enqueue(
			new BattleAction {
				performer = this.character,
				message = string.Format("{0} attacks {1}", this.character.name, victim.name),
				action=Character.Attack,
				target=victim
			}
		);
	}
}
