using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Animator animator;
	string direction;

	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
		float y = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;
		animator.SetFloat("WalkingSpeed", Math.Max(Math.Abs(x), Math.Abs(y)));

		if(x == 0 && y == 0){
			return;
		}

		if(Math.Abs(x) > Math.Abs(y)){
			direction = x > 0 ? "Right" : "Left";
		}else{
			direction = y > 0 ? "Up" : "Down";
		}
		animator.SetTrigger("Look" + direction);

		transform.Translate(x, y, 0);
	}
}
