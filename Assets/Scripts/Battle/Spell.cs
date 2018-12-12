using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Spell", menuName="Spell")]
[System.Serializable]
public class Spell : ScriptableObject {
	public enum Type {
		HEALTH,
		FIRE,
		BOLT,
		WATER
	}
	public int value = 10;
	public int cost = 10;
	public string name = "Spell";
	public string description;
	public Type type;

	public BattleAction Cast(BattleCharacter performer, BattleCharacter target){
		if(this.type == Type.HEALTH){
            return new BattleAction { performer = performer, target = target, action = heal, message = string.Format("{0} heals {1}", performer.character.name, target.character.name) };
		}else{
            return new BattleAction { performer = performer, target = target, action = attack, message = name };
		}
	}

	public void heal(BattleCharacter performer, BattleCharacter target){
		performer.subtractMP(cost);
		target.heal(spellPower(performer));
	}

	public void attack(BattleCharacter performer, BattleCharacter target){
		performer.subtractMP(cost);
		performer.Attack(target, new Attack{
			power = spellPower(performer),
			type = attackTypeFromSpellType(type)
		});
	}

	private int spellPower(BattleCharacter performer){
		return value * performer.character.magic;
	}

	private string attackTypeFromSpellType(Type type){
		switch(type){
			case Type.FIRE:
				return "fire";
			case Type.BOLT:
				return "bolt";
			case Type.WATER:
				return "water";
			default:
				return "physical";
		}
	}
}
