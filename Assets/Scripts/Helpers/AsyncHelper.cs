﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncHelper : MonoBehaviour {
	public static IEnumerator WaitFor(bool condition, System.Action callback){
		if(!condition){
			yield return null;
		}	
		callback.Invoke();
	}

	public static IEnumerator WaitForSeconds(int seconds, System.Action callback){
        yield return new WaitForSeconds(seconds);
		callback.Invoke();
	}
}
