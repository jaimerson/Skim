using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState {
	public enum State{
		WORLD,
		INDOORS,
		IN_BATTLE,
		INVENTORY,
		MAIN_MENU
	}

	public static State currentState;
	private static State previousState;

	public static void Set(State state){
		previousState = currentState;
		currentState = state;
	}

	public static void SetPreviousState(){
		currentState = previousState;
	}
}
