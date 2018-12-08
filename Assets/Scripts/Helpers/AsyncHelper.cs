using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncHelper : MonoBehaviour {
	public static IEnumerator WaitFor(bool condition, System.Action callback){
		if(!condition){
			yield return new WaitForSeconds(0.1f);
		}	
		callback.Invoke();
	}
}
