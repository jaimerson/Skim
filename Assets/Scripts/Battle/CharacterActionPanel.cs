using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterActionPanel : MonoBehaviour {
	public GameObject actions;
	public GameObject stats;
	public Text characterName;

	public BattleCharacter character;
	private Character characterObj { get { return character.character; } }
	private bool waitingForSelection;

	public Button attackButton, itemButton, spellButton;
	public Text health;
	public Text magic;

	public void SetCharacterName(string name){
		this.characterName.text = name;
	}

	// Use this for initialization
	void Start () {
		this.attackButton.onClick.AddListener(attack);
		this.spellButton.onClick.AddListener(spell);
		this.itemButton.onClick.AddListener(item);
	}
	
	// Update is called once per frame
	void Update () {
		this.actions.SetActive(character.character.alive && character.waitingForAction);
		this.health.text = string.Format("{0}/\n{1}", this.characterObj.currentHP, this.characterObj.maxHP);
		this.magic.text = string.Format("{0}/\n{1}", this.characterObj.currentMP, this.characterObj.maxMP);
	}

	private void spell(){
		EnqueueAction(
			new BattleAction {
				performer = this.character,
				message = string.Format("{0} casts spell", this.character.character.name),
				action=BattleCharacter.Spell,
				target=null
			}
		);
	}

	private void item(){
		EnqueueAction(
			new BattleAction {
				performer = this.character,
				message = string.Format("{0} uses item", this.character.character.name),
				action=BattleCharacter.Item,
				target=null
			}
		);
	}

	private void attack(){
		character.waitingForAction = false;
		CharacterSelector.SelectOne(BattleQueue.enemySquad.aliveCharacters());
		StartCoroutine(AsyncHelper.WaitFor(() => CharacterSelector.selectionConfirmed, () => {
			attack(CharacterSelector.selected);
			CharacterSelector.Reset();
		}));
	}

	private void attack(BattleCharacter target){
		EnqueueAction(
			new BattleAction {
				performer = this.character,
				message = string.Format("{0} attacks {1}", this.characterObj.name, target.character.name),
				action=BattleCharacter.Attack,
				target=target
			}
		);
	}

	private void EnqueueAction(BattleAction action){
		this.character.waitingForAction = false;
		BattleQueue.Enqueue(action);
	}

	private IEnumerator wait(){
		yield return new WaitForSeconds(0.1f);
	}
}
