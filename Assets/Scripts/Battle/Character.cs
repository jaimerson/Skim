using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Character : System.Object {
	public string name = "Character";
	public int level = 1;
	public int strength = 10;
	public int magic = 0;
	public int fire_resistance = 0;
	public int water_resistance = 0;
	public int bolt_resistance = 0;
	public int defense = 0;
	public int currentHP = 100;
	public int currentMP = 100;
	public int maxHP = 100;
	public int maxMP = 100;
	public bool alive = true;
	public string prefabPath;

	public int Attack(Character other, Attack attack){
		return other.Defend(attack);
	}

	public int Defend(Attack attack){
		int damage = this.damage(attack);
		takeDamage(damage);
		return damage;
	}

	private void takeDamage(int amount){
		this.currentHP -= amount;
		if(this.currentHP <= 0){
			this.currentHP = 0;
			this.alive = false;
		}
	}
	
	private int damage(Attack attack){
		switch(attack.type){
			case "fire":
				return Math.Max(attack.power - this.fire_resistance, 0);
			case "water":
				return Math.Max(attack.power - this.water_resistance, 0);
			case "bolt":
				return Math.Max(attack.power - this.bolt_resistance, 0);
			default:
				return Math.Max(attack.power - this.defense, 0);
		}
	}
}