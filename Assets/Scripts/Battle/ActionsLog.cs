using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsLog : MonoBehaviour {
	public Text message;
	private Animator animator;

	void Awake(){
		this.animator = GetComponent<Animator>();
	}

	public void setMessage(string message){
		this.message.text = message;	
	}

	public void display(){
		this.animator.SetTrigger("show");
	}

	public void hide(){
		this.animator.SetTrigger("fade");
	}
}
