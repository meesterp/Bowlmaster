using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster : MonoBehaviour {

	// Returns a list of cumulative scores, like a normal score card.
	public static List<int> ScoreCumulative(List<int> rolls){
		int runningTotal = 0;
		List<int> cumulativeScores = new List<int>();
		
		foreach (int frameScore in ScoreFrames(rolls)){
			runningTotal += frameScore;
			cumulativeScores.Add(runningTotal);
		}
		
		return cumulativeScores;
	
	}

	// Returns a list of individual frame scores, NOT cumulative!
	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frames = new List<int>();
		
		for (int i = 1; i < rolls.Count; i+=2) {				// index i points to 2nd bowl of frame
			if (frames.Count == 10) {break;}					// prevents 11th frame score
		
			if (rolls[i-1] + rolls[i] < 10){					// normal "open" frame
				frames.Add(rolls[i-1]+rolls[i]);
			}
			
			if (rolls.Count - i <= 1 ){							// insufficient look-ahead
				break;
			}
			if (rolls[i-1] == 10) {								// STRIKE
				i--;											// STIKE just has one bowl.. don't step ahead 2 places
				frames.Add(10 + rolls[i+1] + rolls[i+2]);
			} else if (rolls[i-1] + rolls[i] ==  10){			// Calculate SPARE bonus
				frames.Add(10 + rolls[i+1]);
			}
		}
		
		return frames;
	}
	
}
