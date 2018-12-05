using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class BattleCharacter : System.Object {

	public Character character;
	public GameObject gameObject;
	public bool waitingForAction;

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

	public static void Item(BattleCharacter spellcaster, BattleCharacter target, Battle battle){
		battle.LogAction("Don't have any items :(");
	}


	public int Attack(BattleCharacter defender, Attack attack){
		int damage = character.Attack(defender.character, attack);
		defender.DisplayDamage(damage);
		animator.SetTrigger("attack");
		return damage;
	}

	public void DisplayDamage(int damage){
		damageText.GetComponent<Text>().text = damage.ToString();
		damageText.GetComponent<Animator>().SetTrigger("show");
		damageText.GetComponent<Animator>().SetTrigger("fade");
	}

	private GameObject damageTextGameObject(){
		UnityEngine.Object prefab = Resources.Load("Prefabs/UI/Damage");
		return MonoBehaviour.Instantiate(prefab) as GameObject;
	}

	private GameObject gameObjectFromCharacter(Character c){
		UnityEngine.Object prefab = Resources.Load(string.Format("Prefabs/Battle/{0}",character.prefabPath));
		return MonoBehaviour.Instantiate(prefab) as GameObject;
	}
}
