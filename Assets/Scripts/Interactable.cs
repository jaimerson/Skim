using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Inherit from this class every time you need something to trigger an
// action when near the player and "e" is pressed.
public class Interactable : MonoBehaviour {

	public const string InteractKey = "e";
	bool nearPlayer;
	private GameObject interactPrompt;
	protected string promptText;

	public virtual void Awake(){
		nearPlayer = false;
		promptText = "Interact"; // default if subclass does not define its own
		Setup();
		StartCoroutine(setupInteractPrompt());
	}

	public virtual void Setup(){
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if(canInteract() && nearPlayer){
			if(Input.GetKey(InteractKey)){
				executeAction();
				interactPrompt.SetActive(false);
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
		enterCollision(collider.gameObject.tag);
	}
	void OnTriggerExit2D(Collider2D collider){
		exitCollision(collider.gameObject.tag);
	}

    void OnCollisionExit2D(Collision2D collider){
		exitCollision(collider.gameObject.tag);
	}

	void OnCollisionEnter2D(Collision2D collider){
		enterCollision(collider.gameObject.tag);
	}

	void enterCollision(string tag){
		if(!canInteract()){
			return;
		}else if(tag == "Player"){
            setupInteractPrompt();
            interactPrompt.SetActive(true);
			nearPlayer = true;
			OnEnterInteractionPossible();
		}
	}

	void exitCollision(string tag){
        interactPrompt.SetActive(false);

		if(!canInteract()){
			return;
		}else if(tag == "Player"){
			nearPlayer = false;
			OnExitInteractionPossible();
		}
	}

	protected virtual void OnEnterInteractionPossible(){
	}

	protected virtual void OnExitInteractionPossible(){
	}

	protected IEnumerator setupInteractPrompt(){
		if(interactPrompt != null) yield return null;
		interactPrompt = InteractPrompt.Create(string.Format("({0}) {1}", InteractKey, promptText));
		yield return null;
	}
}
