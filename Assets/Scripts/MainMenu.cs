using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public Button newGameButton;
	public Button exitButton;
	public List<Character> characters;

	void Start () {
		newGameButton.onClick.AddListener(startNewGame);
		exitButton.onClick.AddListener(exit);
	}

	void exit(){
		Application.Quit();
	}
	
	void startNewGame() {
		Game.current = new Game(characters);
		SceneHelper.GoToScene("MainCave");
	}
}
