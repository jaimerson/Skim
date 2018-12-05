using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public Animator animator;
	public AudioClip stepSound;
	public AudioSource leftAudioSource;
	public AudioSource rightAudioSource;

	private AudioSource audioSource;
	enum Directions { Up, Down, Left, Right };
	int direction;

	void Start () {
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		direction = (int)Directions.Right;
		animator.SetInteger("Direction", direction);
	}

    void Awake()
    {
        if (Exit.playerPosition != null && Exit.playerPosition != Vector3.zero)
        {
            transform.position = Exit.playerPosition;
            Exit.playerPosition.z = Camera.main.transform.position.z;
            Camera.main.transform.position = Exit.playerPosition;
        }
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

	public void PlayStepLeftSound(){
		leftAudioSource.PlayOneShot(stepSound);
	}

	public void PlayStepRightSound(){
		rightAudioSource.PlayOneShot(stepSound);
	}
}
