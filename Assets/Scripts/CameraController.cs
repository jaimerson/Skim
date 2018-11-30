using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = player.transform.position + offset;
	}
}
