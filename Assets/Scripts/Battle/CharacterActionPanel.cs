using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

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
		this.spellButton.interactable = Game.current.spells != null && Game.current.spells.Count > 0;
		this.itemButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		this.actions.SetActive(!waitingForSelection && character.character.alive && character.waitingForAction);
		this.health.text = string.Format("{0}/\n{1}", this.characterObj.currentHP, this.characterObj.maxHP);
		this.magic.text = string.Format("{0}/\n{1}", this.characterObj.currentMP, this.characterObj.maxMP);
	}

	private void spell(){
		this.waitingForSelection = true;
		Selector selector = Selector.Create(Game.current.spells.Cast<IConsumable>().ToList());
		StartCoroutine(AsyncHelper.WaitFor(() => selector.selectionEnded, () =>{
			Spell s = selector.selected as Spell;
			Destroy(selector.gameObject);

			List<BattleCharacter> options;

			if(selector.selected.getType() == "health"){
				options = BattleQueue.alivePlayers();
			}else{
				options = BattleQueue.aliveEnemies();
			}

            CharacterSelector.SelectOne(options);
			StartCoroutine(AsyncHelper.WaitFor(() => CharacterSelector.selectionConfirmed, () => {
				castSpell(s, CharacterSelector.selected);
                CharacterSelector.Reset();
				this.waitingForSelection = false;
			}));
		}));
	}

	private void castSpell(IConsumable _spell, BattleCharacter target){
		Spell spell = (Spell) _spell;
		EnqueueAction(spell.Use(this.character, target));
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
		this.waitingForSelection = true;
		CharacterSelector.SelectOne(BattleQueue.enemySquad.aliveCharacters());
		StartCoroutine(AsyncHelper.WaitFor(() => CharacterSelector.selectionConfirmed, () => {
			attack(CharacterSelector.selected);
			CharacterSelector.Reset();
			this.waitingForSelection = false;
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
}
