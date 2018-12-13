using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Squad : MonoBehaviour {
	public List<BattleCharacter> battleCharacters;
	public List<Character> characters{
		get{
			return new List<Character>(this.battleCharacters.Select(b => b.character));
		}
	}

	public void AddCharacter(Character character, Transform parent){
		BattleCharacter c = new BattleCharacter(character);
		this.battleCharacters.Add(c);
		c.gameObject.transform.SetParent(parent);
		afterAddingCharacter(c);
	}

	protected virtual void afterAddingCharacter(BattleCharacter character){
	}
	protected virtual void onWaitForAction(){
	}

	public List<BattleCharacter> aliveCharacters(){
		return battleCharacters.Where(x => x.character.alive).ToList();
	}

	public bool allDead(){
		return battleCharacters.All(x => !x.character.alive);
	}

	public void WaitForAction(){
		foreach(BattleCharacter c in battleCharacters){
			c.waitingForAction = true;
		}
		onWaitForAction();
	}
}
