using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public EnemyCharacter[] squad;
	public bool alive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!alive){
			Destroy(this.gameObject);
		}	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Player"){
			Battle.Begin(this.squad, Game.current.characters, this);
		}
	}
}
