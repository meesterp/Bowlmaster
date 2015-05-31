using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour {
	public GameObject pinSet;
	
	private Animator animator;
	private PinCounter pinCounter;
	
	void Start(){
		animator = GetComponent<Animator>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}
	// Update is called once per frame
	void Update () {

	}
	
	/*
	void OnTriggerEnter(Collider col){
		GameObject thingHit = col.gameObject;
		
		if (thingHit.GetComponent<Ball>()) {
			standingDisplay.color = Color.red;
			ballOutOfPlay = true;
		}
	}
	*/
	
	void OnTriggerExit(Collider col) {
		GameObject thingLeft = col.gameObject;
		//Destroy (col.transform.parent.gameObject);
		if (thingLeft.GetComponent<Pin>()) {
			Destroy(thingLeft);
		}
		
	}
	
	public void PerformAction(ActionMaster.Action action){
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger("tidyTrigger");
		} else if (action == ActionMaster.Action.Reset || action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMaster.Action.EndGame) {
			throw new UnityException("Endgame not implemented yet");
		}
	}

			
	// methods called from animations
	// raise all standing pins up to clear the swiper path
	public void RaisePins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Raise();			
		}
	}
	
	// lower the raised pins back into place
	public void LowerPins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.Lower ();
		}
	}
	
	public void RenewPins(){
		// lower the raised pins back into place
		// Debug.Log ("Renewing pins");
		Instantiate( pinSet, new Vector3(0,60,1829), Quaternion.identity);
	
	}
	
}
