using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour {
    public bool enable;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        //Exit.GetFinishedPuzzle1();
    }

    public void Close () {
        gameObject.SetActive(true);
    }
}
