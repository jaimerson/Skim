using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherit from this class every time you need something to trigger an
// action when near the player and "e" is pressed.
public class Interactable : MonoBehaviour {

	bool nearPlayer;

	public virtual void Awake(){
		nearPlayer = false;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if(canInteract() && nearPlayer){
			if(Input.GetKey("e")){
				executeAction();
			}
		}
	}

    protected virtual void executeAction(){
        throw new NotImplementedException();
    }

    // TODO: this can be improved somehow
    protected virtual bool canInteract(){
		return true;
	}

	void OnTriggerEnter2D(Collider2D collider){
		enterCollision(collider);
	}
	void OnTriggerExit2D(Collider2D collider){
		exitCollision(collider);
	}

    void OnCollisionExit2D(Collision2D collider){
		exitCollision(collider);
	}

	void OnCollisionEnter2D(Collision2D collider){
		enterCollision(collider);
	}

	void enterCollision(Collision2D collider){
		if(!canInteract()){
			return;
		}else if(collider.gameObject.tag == "Player"){
			nearPlayer = true;
			OnEnterInteractionPossible();
		}
	}

	void enterCollision(Collider2D collider){
		if(!canInteract()){
			return;
		}else if(collider.gameObject.tag == "Player"){
			nearPlayer = true;
			OnEnterInteractionPossible();
		}
	}

	void exitCollision(Collision2D collider){
		if(!canInteract()){
			return;
		}else if(collider.gameObject.tag == "Player"){
			nearPlayer = false;
			OnExitInteractionPossible();
		}
	}

	void exitCollision(Collider2D collider){
		if(!canInteract()){
			return;
		}else if(collider.gameObject.tag == "Player"){
			nearPlayer = false;
			OnExitInteractionPossible();
		}
	}

	protected virtual void OnEnterInteractionPossible(){
	}

	protected virtual void OnExitInteractionPossible(){
	}
}
