using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BattleQueue {
	public static Enemy enemy;
	private static Queue<BattleAction> actions = new Queue<BattleAction>();
	public static PlayerSquad playerSquad;
	public static EnemySquad enemySquad;
	public static List<Character> playerCharacters;
	public static Character[] enemyCharacters;
	public static bool waitingForEnemies = true;
	public static bool waitingForPlayer{
		get {
			return playerSquad.battleCharacters.Any(x => x.waitingForAction);
		}
	}

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
		List<BattleCharacter> enemies = aliveEnemies();
		return enemies[rnd.Next(enemies.Count)];
	}

	public static BattleCharacter randomPlayer(){
		List<BattleCharacter> players = alivePlayers();
		return players[rnd.Next(players.Count)];
	}

	public static List<BattleCharacter> aliveEnemies(){
		return enemySquad.aliveCharacters();
	}

	public static List<BattleCharacter> alivePlayers(){
		return playerSquad.aliveCharacters();
	}

	public static void WaitForPlayers(){
		playerSquad.WaitForAction();
	}

	public static void Reset(){
		playerSquad = null;
		enemySquad = null;
		enemy = null;
		actions.Clear();
		waitingForEnemies = true;
	}
}
