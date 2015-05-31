using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Ball ball;
	private Vector3 offset;
	
	// Use this for initialization
	void Start () {
		//find the ball
		ball = GameObject.FindObjectOfType<Ball>();
		offset = gameObject.transform.position - ball.transform.position;
		
		// find initial ball position
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.gameObject.transform.position.z <= 1829f) {
			gameObject.transform.position = ball.transform.position + offset;
		}
		
	}
}
