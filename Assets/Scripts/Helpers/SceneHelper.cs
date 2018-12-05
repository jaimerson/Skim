using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour {
	private Graphic fade;

	void Awake(){
		Object canvasPrefab = Resources.Load("Prefabs/FadeCanvas");
		GameObject canvas = Instantiate(canvasPrefab) as GameObject;
		this.fade = canvas.transform.GetChild(0).GetComponent<Image>();
		this.fade.gameObject.SetActive(true);
		StartCoroutine(fadeFromBlack());
	}

	public static void GoToScene(string sceneName, LoadSceneMode mode=LoadSceneMode.Single){
		Camera camera = Camera.main;
		SceneHelper helper = camera.GetComponent<SceneHelper>();
		if(mode == LoadSceneMode.Additive){
            camera.GetComponent<AudioListener>().enabled = false;
		}
        helper.LoadScene(sceneName, mode);
	}

	public static void UnloadScene(string sceneName){
		SceneHelper helper = Camera.main.GetComponent<SceneHelper>();
		helper.unloadScene(sceneName);
		Camera.main.GetComponent<AudioListener>().enabled = true;
	}

	public void unloadScene(string sceneName){
        SceneManager.UnloadSceneAsync(sceneName);
		StartCoroutine(fadeFromBlack());
	}

	public void LoadScene(string sceneName, LoadSceneMode mode){
		StartCoroutine(fadeToBlack(
			() => SceneManager.LoadScene(sceneName, mode))
		);
	}

	public IEnumerator fadeToBlack(System.Action action){
		fade.canvasRenderer.SetAlpha(0.0f);
		fade.CrossFadeAlpha(1.0f, 1.0f, true);

		while(fade.canvasRenderer.GetAlpha() < 1.0f){
			yield return null;
		}

		action.Invoke();
	}

	public IEnumerator fadeFromBlack(){
		fade.canvasRenderer.SetAlpha(1.0f);
		fade.CrossFadeAlpha(0.0f, 1.0f, true);

		while(fade.canvasRenderer.GetAlpha() > 0.0f){
			yield return null;
		}
	}
}
