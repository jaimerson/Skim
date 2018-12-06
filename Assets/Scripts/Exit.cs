using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public string sceneName;
    public Vector3 position;
    public static Vector3 playerPosition;
    private bool finishedPuzzle1 = false;

	void OnTriggerEnter2D(Collider2D collider){
        SceneHelper.GoToScene(sceneToLoad());


        if (position != null) {
            Exit.playerPosition = position;
        }
        else
        {
            Exit.playerPosition = Vector3.zero;
        }
    }

	protected virtual string sceneToLoad(){
		// 0 = left
		// 1 = middle
		// 2 = right
		LabyrinthExit.CorrectIndexes = new int[]{0,1,0,2,0,1,2,1,0,0};

        finishedPuzzle1 = true;

		return sceneName;
	}

    public bool GetFinishedPuzzle1 () {
        return finishedPuzzle1;
    }
}
//x 36.98
//y -0.25
//z -0.1852798