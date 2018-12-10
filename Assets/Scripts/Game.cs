using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game {
	public enum State{
		WORLD,
		INDOORS,
		IN_BATTLE,
		INVENTORY,
		MAIN_MENU
	}

	public static State currentState;
	private static State previousState;

	public static void SetState(State state){
		previousState = currentState;
		currentState = state;
	}

	public static void SetPreviousState(){
		currentState = previousState;
	}
}
