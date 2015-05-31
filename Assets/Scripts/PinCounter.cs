using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour {
	public Text standingDisplay;
	
	private GameManager gameManager;
	private int lastStandingCount = -1;
	private float lastChangeTime;
	private int lastSettledCount = 10;
	private bool ballOutOfPlay = false;
	
	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString();
		
		if (ballOutOfPlay) {
			checkStanding();
			standingDisplay.color = Color.red;
		}
	}
	
	public void Reset() {
		lastSettledCount = 10;
	}
	
	void checkStanding(){
		// update the lastStandingCount
		// Call PinsHaveSettled(). When they have 
		int standingNow = CountStanding();
		float settleTime = 3f;
		
		if (standingNow != lastStandingCount){
			lastStandingCount = standingNow;
			lastChangeTime = Time.time;
			return;
		}
		
		if ((Time.time - lastChangeTime) > settleTime) {
			PinsHaveSettled();
		}
	}
	
	void PinsHaveSettled(){
		int standing = CountStanding();
		int pinFall = lastSettledCount - standing;
		lastStandingCount = standing;
		
		gameManager.Bowl(pinFall);
		
		lastStandingCount = -1;
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
	}
	
	
	int CountStanding(){
		int numberOfStandingPins = 0;
		
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()){
				numberOfStandingPins++;
			}
		}
		return numberOfStandingPins;
	}
	
	void OnTriggerExit(Collider col){
		GameObject thingLeft = col.gameObject;
		if (thingLeft.GetComponent<Ball>()) {
			ballOutOfPlay = true;
		}
	}
	
}
