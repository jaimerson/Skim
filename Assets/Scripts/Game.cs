using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game {

	public List<Character> characters;
	public List<Spell> spells;

	public static Game current = defaultGame;

	// This is for ease of development, normally should not be used
	private static Game defaultGame {
		get {
			List<Character> characters = new List<Character>();
			List<Spell> spells = new List<Spell>();

			characters.Add(
				new Character {
					name="Jack",
					strength=100,
					defense=100,
					magic=100,
					prefab=GameObject.Instantiate(Resources.Load("Prefabs/Battle/Jack"))
				}	
			);
			Game game =  new Game(characters);
			game.spells = spells;

			return game;
		}
	}

	public Game(List<Character> characters){
		this.characters = new List<Character>();
		foreach(Character c in characters){
			this.characters.Add(GameObject.Instantiate(c) as Character);
		}
	}

}
