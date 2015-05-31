﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {

	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
	private List<int> pinFalls;

	[SetUp]
	public void Setup(){
		pinFalls = new List<int>();
	}

//	[Test]
//	public void T00_PassingTest(){
//		Assert.AreEqual(1,1);
//	}

//	[Test]
//	public void T01_OneStrikeReturnsEndTurn() {
//		pinFalls.Add(10);
//		Assert.AreEqual(endTurn,ActionMaster.NextAction(pinFalls));
//	}
//
//	[Test]
//	public void T02_Bowl8ReturnsTidy() {
//		pinFalls.Add(8);
//		Assert.AreEqual(tidy,ActionMaster.NextAction(pinFalls));
//	}
//
//	[Test]
//	public void T03_Bowl2_8ReturnsEndTurn() {
//		int[] rolls = {8, 2};
//		Assert.AreEqual(endTurn,ActionMaster.NextAction(rolls.ToList()));
//	}	
//	
//	[Test]
//	public void T04_CheckResetAtStrikeInLastFrame(){
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10 };	// 9 pairs of rolls up to ball #18
//		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
//	}
//	
//	[Test]
//	public void T05_CheckResetAtSpareInLastFrame(){
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9 };	// 9 pairs of rolls up to ball #18
//		Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
//	}
//	
//	[Test]
//	public void T06_YoutubeRollsEndInEndgame(){
//		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2, 9 };  //,9
//		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//	}
//	
//	[Test]
//	public void T07_GameEndsAtBowl20(){
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1, 1 }; // 19 rolls
//		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//	}
//
//	[Test]
//	public void T08_CheckTidyAtBowl20AndNoClearUp(){
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 5 }; // 19 rolls
//		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
//	}
//
//	[Test]
//	public void T09_CheckTidyAtBowl20AndGutterBall(){
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 0 }; // 19 rolls
//		Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
//	}	
//	
//	[Test]
//	public void T10_CheckEndTurnAfterSpareAnd2Bowls(){
//		int[] rolls = {0, 10, 5, 1 }; 
//		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//	}	
//	
//	[Test]
//	public void T11_Dondi10thFrameTurkey(){
//		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 10, 10 }; 
//		Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
//	}	
//	
//	[Test]
//	public void T12_ZeroOneGivesEndturn(){
//		int[] rolls = {0, 1}; 
//		Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
//	}	
}