using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAction  {
	public System.Action<Character, Character, Battle> action;
	public string message;
	public Character performer;
	public Character target;

	public void perform(Battle battle){
		this.action(this.performer, this.target, battle);
	}
}
