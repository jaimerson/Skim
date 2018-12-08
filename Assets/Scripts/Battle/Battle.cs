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

	private bool executingAction = false;

	public static void Begin(Character[] players, Character[] enemies, Enemy enemy){
		BattleQueue.playerCharacters = enemies;
		BattleQueue.enemyCharacters = players;
		BattleQueue.enemy = enemy;
		SceneHelper.GoToScene("Battle", LoadSceneMode.Additive);
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
			BattleQueue.WaitForPlayers();
			BattleQueue.waitingForEnemies = true;
		}
		if(BattleQueue.waitingForPlayer || executingAction){
			return;
		}
		if(BattleQueue.waitingForEnemies){
			enemies.takeTurn();
			return;
		}
		BattleAction action = BattleQueue.Dequeue();
		if(action != null){
			executingAction = true;
			StartCoroutine(LogAction(action.message, () => performAction(action)));
		}
	}

	private void performAction(BattleAction action){
		action.perform(this);
		executingAction = false;
	}

	private void win(){
		LogAction("You won!");
        enemy.alive = false;
		endBattle();
	}

	private void endBattle(){
		BattleQueue.Reset();
        SceneHelper.UnloadScene("Battle");
	}

	public IEnumerator LogAction(string message, System.Action callback){
		yield return StartCoroutine(LogAction(message));
		callback.Invoke();
	}

	public IEnumerator LogAction(string message){
		actionsLog.setMessage(message);
		actionsLog.display();
		yield return StartCoroutine(waitAndCloseActionLog(3));
	}

	private IEnumerator waitAndCloseActionLog(int seconds){
		yield return new WaitForSeconds(seconds);
		actionsLog.hide();
	}
}