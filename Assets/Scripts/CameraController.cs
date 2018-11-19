using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	private Vector3 offset;
	public Graphic fade;

	// Use this for initialization
	void Start()
	{
		fadeFromBlack();
		player = GameObject.Find("Player");
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = player.transform.position + offset;
	}

	public void fadeFromBlack(){
		fade.canvasRenderer.SetAlpha(1.0f);
		fade.gameObject.SetActive(true);
		fade.CrossFadeAlpha(0.0f, 1.0f, true);
	}
	public IEnumerator fadeToBlack(System.Action action){
		fade.canvasRenderer.SetAlpha(0.0f);
		fade.CrossFadeAlpha(1.0f, 1.0f, true);

		while(fade.canvasRenderer.GetAlpha() < 1.0f){
			yield return null;
		}

		action.Invoke();
	}
}
