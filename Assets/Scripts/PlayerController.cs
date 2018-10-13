using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	Animator animator;
	enum Directions { Up, Down, Left, Right };
	int direction;

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
			direction = x > 0 ? (int)Directions.Right : (int)Directions.Left;
		}else{
			direction = y > 0 ? (int)Directions.Up : (int)Directions.Down;
		}
		animator.SetInteger("Direction", direction);

		transform.Translate(x, y, 0);
	}
}
