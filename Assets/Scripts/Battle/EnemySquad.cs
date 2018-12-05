using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquad : Squad {

    public void takeTurn(){
        foreach(BattleCharacter c in characters){
            enqueueAttack(c);
        }
        BattleQueue.waitingForEnemies = false;
    }

    private void enqueueAttack(BattleCharacter character){
		BattleCharacter victim = BattleQueue.randomPlayer();
        BattleQueue.Enqueue(
            new BattleAction{
                performer = character,
                message = string.Format("{0} attacks {1}", character.character.name, victim.character.name),
                action = BattleCharacter.Attack,
                target = victim
            }
        );
    }
}
