using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleQueue {
	public static Enemy enemy;
	private static Queue<BattleAction> actions = new Queue<BattleAction>();
	public static PlayerSquad playerSquad;
	public static EnemySquad enemySquad;
	public static Character[] playerCharacters;
	public static Character[] enemyCharacters;
	public static bool finished;

	private static System.Random rnd = new System.Random();

	public static bool Empty(){
		return actions.Count == 0;
	}

	public static BattleAction Peek(){
		return actions.Peek();
	}

	public static void Enqueue(BattleAction action){
		actions.Enqueue(action);
	}

	public static BattleAction Dequeue(){
		return actions.Dequeue();
	}

	public static BattleCharacter randomEnemy(){
		List<BattleCharacter> enemies = enemySquad.aliveCharacters();
		return enemies[rnd.Next(enemies.Count)];
	}

	public static List<BattleCharacter> aliveEnemies(){
		return enemySquad.aliveCharacters();
	}

	public static List<BattleCharacter> alivePlayers(){
		return playerSquad.aliveCharacters();
	}

	public static void Reset(){
		playerSquad = null;
		enemySquad = null;
		enemy = null;
		finished = false;
		actions.Clear();
	}
}
