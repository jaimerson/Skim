using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour {
	public List<Character> characters;
	protected Transform squadPanel;

	public void AddCharacter(Character character){
		this.characters.Add(character);
	}
}
