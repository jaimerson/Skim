using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Squad : MonoBehaviour {
	public List<BattleCharacter> characters;

	public void AddCharacter(Character character, Transform parent){
		BattleCharacter c = new BattleCharacter(character);
		this.characters.Add(c);
		c.gameObject.transform.SetParent(parent);
		afterAddingCharacter(character);
	}

	protected virtual void afterAddingCharacter(Character character){
	}

	public List<BattleCharacter> aliveCharacters(){
		return characters.Where(x => x.character.alive).ToList();
	}

	public bool allDead(){
		return characters.All(x => !x.character.alive);
	}
}
