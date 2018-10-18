﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChestController : MonoBehaviour {
	Animator animator;
	bool open;
	bool nearPlayer;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		open = false;
		nearPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(nearPlayer){
			if(Input.GetKey("e")){
				animator.SetTrigger("open");
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		Debug.Log("collided");
		if(open){
			return;
		}else if(collider.gameObject.tag == "Player"){
			nearPlayer = true;
		}
	}
}
