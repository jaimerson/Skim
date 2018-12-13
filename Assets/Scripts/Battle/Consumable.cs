using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConsumable{
	BattleAction Use(BattleCharacter performer, BattleCharacter target);
	string getName();
	string getType();
}