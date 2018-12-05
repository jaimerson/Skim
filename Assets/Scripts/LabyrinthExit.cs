using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LabyrinthExit : Exit {

	public int index;
	const string entranceSceneName = "LabyrinthOfDoom_Entrance";
	const string finalSceneName = "LabyrinthOfDoom_Exit";
	public static int[] CorrectIndexes;


    protected override string sceneToLoad(){
		if(index == correctIndex()){            
            return nextSceneName();
		}else{
           
            return entranceSceneName;
		}
	}

	private string nextSceneName(){
		if(CorrectIndexes == null || CorrectIndexes.Length == 0){
			return finalSceneName;
		}
		return sceneName;
	}

	private int correctIndex(){
		if(CorrectIndexes != null && CorrectIndexes.Length > 0){
			int correct = CorrectIndexes[0];
			CorrectIndexes = CorrectIndexes.Skip(1).ToArray();
           
            return correct;
           
		}
		return -1;
	}
}