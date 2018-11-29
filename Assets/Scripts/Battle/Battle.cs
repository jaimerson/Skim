using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour {

	public GameObject actionsLogGameObject;
	public GameObject playerSquad;
	public GameObject enemySquad;
	public GameObject actionsPanel;
	private ActionsLog actionsLog;

	private PlayerSquad heroes;
	private EnemySquad enemies;

	public static void Begin(Character[] players, Character[] enemies){
		BattleQueue.playerCharacters = enemies;
		BattleQueue.enemyCharacters = players;
		SceneManager.LoadScene("Battle");
	}

	// Use this for initialization
	void Start () {
		this.actionsLog = this.actionsLogGameObject.GetComponent<ActionsLog>();
		this.heroes = this.actionsPanel.GetComponent<PlayerSquad>();
		this.enemies = this.actionsPanel.GetComponent<EnemySquad>();
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
		heroes.AddCharacter(hero);
		GameObject heroObject = gameObjectFromCharacter(hero);
		heroObject.transform.SetParent(playerSquad.transform, true);
	}

	void AddEnemy(Character enemy){
		enemies.characters.Add(enemy);
		GameObject enemyObject = gameObjectFromCharacter(enemy);
		enemyObject.transform.SetParent(enemySquad.transform, true);
	}

	GameObject gameObjectFromCharacter(Character character){
		UnityEngine.Object prefab = Resources.Load(string.Format("Prefabs/Battle/{0}",character.prefabPath));
		return Instantiate(prefab) as GameObject;
	}

	// Update is called once per frame
	void Update () {
		if(BattleQueue.Empty()){
			return;
		}
		BattleAction action = BattleQueue.Dequeue();
		if(action != null){
			LogAction(action.message);
			action.perform(this);
		}
	}

	public void LogAction(string message){
		actionsLog.setMessage(message);
		actionsLog.display();
		StartCoroutine(waitAndCloseActionLog(2));
	}

	private IEnumerator waitAndCloseActionLog(int seconds){
		yield return new WaitForSeconds(seconds);
		actionsLog.hide();
	}
}