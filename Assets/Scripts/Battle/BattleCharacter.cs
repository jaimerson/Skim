using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleCharacter : System.Object {

	public Character character;
	public GameObject gameObject;
	private Animator animator;

	public BattleCharacter(Character character){
		this.character = character;
		this.gameObject = gameObjectFromCharacter(character);
		this.animator = gameObject.GetComponent<Animator>();
	}

	private GameObject gameObjectFromCharacter(Character c){
		UnityEngine.Object prefab = Resources.Load(string.Format("Prefabs/Battle/{0}",character.prefabPath));
		return MonoBehaviour.Instantiate(prefab) as GameObject;
	}
}
