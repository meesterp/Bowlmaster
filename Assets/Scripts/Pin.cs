using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f;  // degrees of tilt
	public float distanceToRaise = 45f;
	private Rigidbody rigidBody;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//print (name + IsStanding());
	}
	
	// returns false if angle of pin larger then threshold. true if less
	public bool IsStanding() {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs (270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs (rotationInEuler.z);    // zero would be upright
		
		if (tiltInX < standingThreshold  && tiltInZ < standingThreshold) {
			return true;
		} else {
			return false;
		}
		
	}
	
	// methods called from animations
	// raise all standing pins up to clear the swiper path
	public void Raise(){
		Debug.Log ("Raising pin: " + name);
		if (IsStanding()) {
			rigidBody.useGravity = false;
			transform.Translate (new Vector3(0,distanceToRaise,0), Space.World);
			//transform.rotation = Quaternion.Euler(new Vector3(270,0,0));
			transform.rotation = Quaternion.Euler(270f,0f,0f);
		}
		
	}
	
	// lower the raised pins back into place
	public void Lower(){
		Debug.Log ("Lowering pin:" + name);
		transform.Translate (new Vector3(0,(-distanceToRaise),0), Space.World);
		rigidBody.useGravity = true;
		transform.rotation = Quaternion.Euler(270f,0f,0f);
		
	}
	
}
