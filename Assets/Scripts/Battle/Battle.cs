using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
	private bool battleOver = false;

	public static void Begin(Character[] players, List<Character> enemies, Enemy enemy){
		BattleQueue.playerCharacters = enemies;
		BattleQueue.enemyCharacters = players;
		BattleQueue.enemy = enemy;
		SceneHelper.GoToScene("Battle", LoadSceneMode.Additive);
	}

	// Use this for initialization
	void Start () {
		GameState.Set(GameState.State.IN_BATTLE);
		this.actionsLog = this.actionsLogGameObject.GetComponent<ActionsLog>();
		this.heroes = this.actionsPanel.GetComponent<PlayerSquad>();
		this.enemies = this.actionsPanel.GetComponent<EnemySquad>();
		this.enemy = BattleQueue.enemy;
		foreach(Character h in BattleQueue.playerCharacters){
			AddHero(Instantiate(h));
		}
		foreach(Character e in BattleQueue.enemyCharacters){
			AddEnemy(Instantiate(e));
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
		if(battleOver) { return; }
		if(enemies.allDead()){
			win();
			return;
		}
		if(heroes.allDead()){
			lose();
			return;
		}
		if(BattleQueue.Empty() && !executingAction){
			BattleQueue.WaitForPlayers();
			BattleQueue.waitingForEnemies = true;
			return;
		}
		if(BattleQueue.waitingForPlayer || executingAction){
			return;
		}
		if(BattleQueue.waitingForEnemies){
			enemies.takeTurn();
			return;
		}
		BattleAction action = BattleQueue.Dequeue();
		if(action != null && action.canBePerformed()){
			executingAction = true;
			LogAction(action.message, () => performAction(action));
		}
	}

	private void performAction(BattleAction action){
		action.perform(this);
		executingAction = false;
	}

	private void win(){
		battleOver = true;
		LogAction("You won!", () => {
			enemy.alive = false;
			endBattle();
		});
	}

	private void lose(){
		battleOver = true;
		LogAction("You lost!", () => {
			UnityEngine.Object gameOverPrefab = Resources.Load("Prefabs/UI/GameOverCanvas");
			GameObject gameOverCanvas = Instantiate(gameOverPrefab) as GameObject;
			GameObject panel = gameOverCanvas.transform.GetChild(0).gameObject;
			Graphic image = panel.GetComponent<Image>();
			image.canvasRenderer.SetAlpha(0.0f);
			image.CrossFadeAlpha(1.0f, 3.0f, true);
			StartCoroutine(AsyncHelper.WaitFor(() => image.canvasRenderer.GetAlpha() >= 1.0f, () => {
				StartCoroutine(AsyncHelper.WaitForSeconds(5, () => SceneHelper.GoToScene("MainMenu")));
			}));
		});
	}

	private void endBattle(){
		GameState.SetPreviousState();
		Game.current.characters = heroes.characters;
        SceneHelper.UnloadScene("Battle");
		BattleQueue.Reset();
	}

	public void LogAction(string message, System.Action callback){
		StartCoroutine(logAction(message, callback));
	}

	private IEnumerator logAction(string message, System.Action callback){
		yield return StartCoroutine(LogAction(message));
		callback.Invoke();
	}

	public IEnumerator LogAction(string message){
		actionsLog.setMessage(message);
		actionsLog.display();
		yield return StartCoroutine(AsyncHelper.WaitForSeconds(2, () => actionsLog.hide()));
	}
}