using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Animator animator;
	enum Directions { Up, Down, Left, Right };
	int direction;

	void Start () {
		animator = GetComponent<Animator>();
		direction = (int)Directions.Right;
		animator.SetInteger("Direction", direction);
	}

	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
		float y = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;
		animator.SetFloat("WalkingSpeed", Math.Max(Math.Abs(x), Math.Abs(y)));

		if(x == 0 && y == 0){ return; }

		if (Math.Abs(x) > Math.Abs(y)) {
			if (x > 0) {
				direction = (int)Directions.Right;
			} else {
				direction = (int)Directions.Left;
			}
		} else {
			if (y > 0) {
				direction = (int)Directions.Up;
			} else {
				direction = (int)Directions.Down;
			}
		}

		animator.SetInteger("Direction", direction);

		transform.Translate(x, y, 0);
	}
}
