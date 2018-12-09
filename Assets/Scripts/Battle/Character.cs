using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Character : ScriptableObject {
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
	public UnityEngine.Object prefab;

	private Dictionary<string, int> resistances {
		get {
			return new Dictionary<string, int> {
				{"fire", fire_resistance},
				{"bolt", bolt_resistance},
				{"water", water_resistance}
			};
		}
	}

	private readonly float resistanceMultiplier = 0.3f;
	private System.Random random = new System.Random();

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
		int resistance = attack.type != null && resistances.ContainsKey(attack.type) ? resistances[attack.type] : this.defense;
		double power = random.Next(-5, 5) + attack.power; // For aesthetics but doesn't really affect gameplay that much
		return (int) Math.Max(power - resistance * this.resistanceMultiplier, 0);
	}
}