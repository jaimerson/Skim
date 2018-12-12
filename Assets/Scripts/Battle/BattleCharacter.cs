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

	public static void Attack(BattleCharacter attacker, BattleCharacter defender){
		attacker.Attack(defender, new Attack { power = attacker.character.strength });
	}

	public static void Spell(BattleCharacter spellcaster, BattleCharacter target){
	}

	public static void Item(BattleCharacter itemUser, BattleCharacter target){
	}

	public void subtractMP(int value){
		this.character.currentMP -= value;
	}

	public void heal(int value){
		if(character.dead){
			return;
		}
		character.currentHP += value;
		if(character.currentHP > character.maxHP){
			character.currentHP = character.maxHP;
		}
		DisplayHeal(value);
	}


	public int Attack(BattleCharacter defender, Attack attack){
		int damage = defender.Defend(attack);
		animator.SetTrigger("attack");
		return damage;
	}

	public int Defend(Attack attack){
		int damage = character.Defend(attack);
		DisplayDamage(damage);
		if(character.dead){
			animator.SetTrigger("die");
		}
		return damage;
	}

	public void DisplayHeal(int amount){
		damageText.GetComponent<Text>().text = string.Format("+{0}", amount);
		damageText.GetComponent<Animator>().SetTrigger("show");
		damageText.GetComponent<Animator>().SetTrigger("fade");
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
