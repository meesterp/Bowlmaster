using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball)) ]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 startPosition, endPosition;
	private float startTime, endTime;
	
	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}
	
	public void dragStart(){
		if (!ball.inPlay) {
			//capture time and position of dragstart or mouseclick
			startPosition = Input.mousePosition;
			startTime = Time.time;
		}
	
	}

	public void dragEnd(){
		//launch ball
		if (!ball.inPlay){
			endPosition = Input.mousePosition;
			endTime = Time.time;
			
			float duration = endTime - startTime;  // duration in seconds
			
			float launchSpeedX = (endPosition.x - startPosition.x)/duration;
			float launchSpeedZ = (endPosition.y - startPosition.y)/duration;
			
			Vector3 velocity = new Vector3(launchSpeedX, 0f, launchSpeedZ);
			
			ball.Launch(velocity);
		}
	}
	
	public void MoveStart(float xNudge){
		//print ("nudge " + xNudge);
		if (!ball.inPlay){
			if ((ball.transform.position.x + xNudge > -51.7f)  && (ball.transform.position.x + xNudge < 51.7f)) {
				ball.transform.Translate(new Vector3(xNudge, 0, 0));
			}
		}
	}

}
