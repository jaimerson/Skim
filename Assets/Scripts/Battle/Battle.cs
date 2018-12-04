using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour {

    public Enemy enemy;
	public GameObject actionsLogGameObject;
	public GameObject playerSquad;
	public GameObject enemySquad;
	public GameObject actionsPanel;
	private ActionsLog actionsLog;

	private PlayerSquad heroes;
	private EnemySquad enemies;

	public static void Begin(Character[] players, Character[] enemies, Enemy enemy){
		BattleQueue.playerCharacters = enemies;
		BattleQueue.enemyCharacters = players;
		BattleQueue.enemy = enemy;
		SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
	}

	// Use this for initialization
	void Start () {
		this.actionsLog = this.actionsLogGameObject.GetComponent<ActionsLog>();
		this.heroes = this.actionsPanel.GetComponent<PlayerSquad>();
		this.enemies = this.actionsPanel.GetComponent<EnemySquad>();
		this.enemy = BattleQueue.enemy;
		foreach(Character h in BattleQueue.playerCharacters){
			AddHero(h);
		}
		foreach(Character e in BattleQueue.enemyCharacters){
			AddEnemy(e);
		}
		BattleQueue.playerSquad = this.heroes;
		BattleQueue.enemySquad = this.enemies;
		LogAction("Battle started!");
	}

	void AddHero(Character hero){
		heroes.AddCharacter(hero, playerSquad.transform);
	}

	void AddEnemy(Character enemy){
		enemies.AddCharacter(enemy, enemySquad.transform);
	}

	// Update is called once per frame
	void Update () {
		if(enemies.allDead()){
			win();
		}
		if(BattleQueue.Empty()){
			return; // TODO: wait for player and enemy turns
		}
		BattleAction action = BattleQueue.Dequeue();
		if(action != null){
			LogAction(action.message);
			action.perform(this);
		}
	}

	private void win(){
		LogAction("You won!");
        enemy.alive = false;
		endBattle();
	}

	private void endBattle(){
		BattleQueue.Reset();
        SceneManager.UnloadSceneAsync("Battle");
	}

	public void LogAction(string message){
		actionsLog.setMessage(message);
		actionsLog.display();
		StartCoroutine(waitAndCloseActionLog(3));
	}

	private IEnumerator waitAndCloseActionLog(int seconds){
		yield return new WaitForSeconds(seconds);
		actionsLog.hide();
	}
}