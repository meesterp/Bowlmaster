using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	//public float launchSpeed;
	public Vector3 launchVelocity;
	public bool inPlay = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startPosition;
	
	// Use this for initialization
	void Start () {
		// retrieve GameObjects
		rigidBody = gameObject.GetComponent<Rigidbody>();
		audioSource = gameObject.GetComponent<AudioSource>();
		
		rigidBody.useGravity = false;
		startPosition = transform.position;
	}
	
	public void Launch (Vector3 velocity)
	{
		inPlay = true;
		rigidBody.velocity = velocity;  //new Vector3 (0, 0, launchSpeed);
		rigidBody.useGravity = true;
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Reset(){
		inPlay = false;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero; //new Vector3(0,0,0);
		rigidBody.angularVelocity = Vector3.zero;
		transform.position = startPosition;
		transform.rotation = Quaternion.identity;
	}
	
	public void TestLaunch() {
		Launch(new Vector3(Random.Range (-15, 15),0,Random.Range (400,500)));
	}
	
}