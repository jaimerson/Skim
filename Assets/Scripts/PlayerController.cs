using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Animator animator;
	public AudioClip stepSound;
	public AudioSource leftAudioSource;
	public AudioSource rightAudioSource;

	private AudioSource audioSource;
	private Rigidbody2D body;
	private Vector3 previousPosition;
	private Vector3 newPosition;
	public enum Directions { Up, Down, Left, Right };
	int direction;

	void Start () {
		GameState.Set(GameState.State.INDOORS);
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		direction = (int)Directions.Right;
		animator.SetInteger("Direction", direction);
		this.body = GetComponent<Rigidbody2D>();
		this.previousPosition = transform.position;
		this.newPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(GameState.currentState != GameState.State.WORLD && GameState.currentState != GameState.State.INDOORS){
			return;
		}

		newPosition = transform.position;
		Vector3 velocity = (newPosition - previousPosition) / Time.fixedDeltaTime;

		animator.SetFloat("WalkingSpeed", Math.Abs(Math.Max(velocity.x, velocity.y)));
		Debug.Log(Math.Abs(Math.Max(velocity.x, velocity.y)));
		previousPosition = newPosition;

		float x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
		float y = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;

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

		body.MovePosition(new Vector2(transform.position.x + x, transform.position.y + y));
	}

	public void PlayStepLeftSound(){
		leftAudioSource.PlayOneShot(stepSound);
	}

	public void PlayStepRightSound(){
		rightAudioSource.PlayOneShot(stepSound);
	}
}
