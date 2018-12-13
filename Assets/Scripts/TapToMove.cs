using UnityEngine;
using System.Collections;

public class TapToMove : MonoBehaviour
{
    //flag to check if the user has tapped / clicked. 
    //Set to true on click. Reset to false on reaching destination
    private bool flag = false;
    //destination point
    private Vector3 endPoint;
    //alter this to change the speed of the movement of player / gameobject
    private float duration = 3.0f;

    void Update()
    {
        if(GameState.currentState != GameState.State.INDOORS && GameState.currentState != GameState.State.WORLD){
            return;
        }
		if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0){
			flag = false;
		}

        //check if the screen is touched / clicked   
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetMouseButtonDown(0)))
        {
            //Create a Ray on the tapped / clicked position
            Ray ray;
            //for touch device
			#if (UNITY_ANDROID || UNITY_IPHONE || UNITY_WP8)
 			ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            #else
            //for other devices
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			#endif

			flag = true;
			endPoint = ray.origin;
            //Check if the ray hits any collider

        }
        //check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
        if (flag && !Mathf.Approximately(transform.position.magnitude, endPoint.magnitude))
        { //&& !(V3Equal(transform.position, endPoint))){
          //move the gameobject to the desired position
            gameObject.GetComponent<Rigidbody2D>().MovePosition(Vector3.Lerp(transform.position, endPoint, 1 / (duration * (Vector3.Distance(transform.position, endPoint)))));
        }
        //set the movement indicator flag to false if the endPoint and current gameobject position are equal
        else if (flag)
        {
            flag = false;
        }

    }
}