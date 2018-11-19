using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public string sceneName;

	void OnTriggerEnter2D(Collider2D collider){
		StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraController>().fadeToBlack(
			() => SceneManager.LoadScene(sceneToLoad())
		));
	}

	protected virtual string sceneToLoad(){
		// 0 = left
		// 1 = middle
		// 2 = right
		LabyrinthExit.CorrectIndexes = new int[]{0,1,0,2,0,1,2,1,0,0};
		return sceneName;
	}
}
