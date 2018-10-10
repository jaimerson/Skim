using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
		var y = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;

		transform.Translate(x, y, 0);
	}
}
