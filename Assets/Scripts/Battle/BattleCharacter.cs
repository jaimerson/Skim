using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BattleCharacter : System.Object {

	public Character character;
	public GameObject gameObject;
	public bool waitingForAction;

	public bool alive {
		get {
			return character.alive;
		}
	}

	private GameObject damageText;
	private Animator animator;


	public BattleCharacter(Character character){
		this.character = character;
		this.gameObject = gameObjectFromCharacter(character);
		this.damageText = damageTextGameObject();
		damageText.transform.position = gameObject.transform.position;
		damageText.transform.SetParent(gameObject.transform);
		this.animator = gameObject.GetComponent<Animator>();
	}

	public static void Attack(BattleCharacter attacker, BattleCharacter defender, Battle battle){
		attacker.Attack(defender, new Attack { power = attacker.character.strength });
	}

	public static void Spell(BattleCharacter spellcaster, BattleCharacter target, Battle battle){
		battle.LogAction("Don't know any spells :(");
	}

	public static void Item(BattleCharacter itemUser, BattleCharacter target, Battle battle){
		battle.LogAction("Don't have any items :(");
	}


	public int Attack(BattleCharacter defender, Attack attack){
		int damage = defender.Defend(attack);
		animator.SetTrigger("attack");
		return damage;
	}

	public int Defend(Attack attack){
		int damage = character.Defend(attack);
		DisplayDamage(damage);
		return damage;
	}

	public void DisplayDamage(int damage){
		damageText.GetComponent<Text>().text = damage == 0 ? "miss" : damage.ToString();
		damageText.GetComponent<Animator>().SetTrigger("show");
		damageText.GetComponent<Animator>().SetTrigger("fade");
	}

	private GameObject damageTextGameObject(){
		UnityEngine.Object prefab = Resources.Load("Prefabs/UI/Damage");
		return MonoBehaviour.Instantiate(prefab) as GameObject;
	}

	private GameObject gameObjectFromCharacter(Character c){
		return MonoBehaviour.Instantiate(c.prefab) as GameObject;
	}
}
