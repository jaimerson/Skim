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

	public List<Character> characters;

	public static Game current = defaultGame;

	// This is for ease of development, normally should not be used
	private static Game defaultGame {
		get {
			List<Character> characters = new List<Character>();
			characters.Add(
				new Character {
					name="Jack",
					strength=100,
					defense=100,
					prefab=GameObject.Instantiate(Resources.Load("Prefabs/Battle/Jack"))
				}	
			);
			return new Game(characters);
		}
	}

	public Game(List<Character> characters){
		this.characters = new List<Character>();
		foreach(Character c in characters){
			this.characters.Add(GameObject.Instantiate(c) as Character);
		}
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
