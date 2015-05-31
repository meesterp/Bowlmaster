using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {

	public enum Action {Tidy, Reset, EndTurn, EndGame};	
	private int[] bowls = new int[21];
	private int bowl = 1;
	

	public static Action NextAction(List<int> pinFalls){
		ActionMaster am = new ActionMaster();
		Action currentAction = new Action();
		
		foreach (int pinFall in pinFalls) {
			currentAction =  am.Bowl(pinFall);
		}
		
		return currentAction;
	}


	// Use this for initialization
	private Action Bowl (int pins) {
		//Debug.Log ("Inside function Bowl with score: " + pins);
		if (pins < 0 || pins > 10){	throw new UnityException("Number of pins should be between 0 and 10 inclusive. Received: " + pins);	}
		
		//register the values in the bowls array
		// Remember bowls array start counting at zero, hence the -1 below
		bowls[bowl-1] = pins;
		//Debug.Log ("bowls is now: " + bowl);
		
		if (bowl == 21){
			return Action.EndGame;
		}
		
		if (bowl >= 19 && pins == 10) {   // strike on bowl 19
			bowl += 1;
			return Action.Reset;
		}
		
		// handle cases for ball #20
		if (bowl == 20) {
			//Debug.Log ("bowl=20, #18:" + bowls[18] + " , #19: " + bowls[19]);
			bowl += 1;
			if (bowls[18] == 10 && bowls[19] != 10)  {
				return Action.Tidy;
			} else if ((bowls[18] + bowls[19]) == 10) {
				return Action.Reset;
			} else if(Bowl21Awarded()) {
				return Action.Tidy;
			} else { 
				return Action.EndGame;
			}
		}
		
		
		// if first ball of frame...
		if (bowl % 2 != 0) {  //first bowl of frame
			if (pins == 10){  // strike !!
				bowl += 2;
				return Action.EndTurn;
			} 
			bowl += 1;
			return Action.Tidy;		
		} else if (bowl % 2 == 0) { // end of frame
			bowl += 1;
			return Action.EndTurn;
		}
	
	
		throw new UnityException ("Action to be returned cannot be determined");
	}
	
	private bool Bowl21Awarded(){
		//Debug.Log ("IS Bowl 21 awarded ??");
		// Remember bowls array start counting at zero, hence the -1 below
		return (bowls[19-1] + bowls[20-1] >= 10);
	}
	
}
