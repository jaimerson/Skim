using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAction  {
	public System.Action<BattleCharacter, BattleCharacter, Battle> action;
	public string message;
	public BattleCharacter performer;
	public BattleCharacter target;

	public bool canBePerformed(){
		return performer.alive;
	}

	public void perform(Battle battle){
		this.action(this.performer, this.target, battle);
	}
}
