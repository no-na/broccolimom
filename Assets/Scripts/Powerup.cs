using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Powerup : MonoBehaviour {
	
	public enum Player {SISTER, BROTHER, BOTH};
	[SerializeField]
	protected Player affectedPlayer; // Who this powerup can effect
	protected GameObject affectedPlayerObject; // The actual gameobject of the player
	
	// Checks if the player can pick the powerup up or not.
	public bool IsRelevant(){
		print("hi");
		print(affectedPlayerObject.name);
		if(affectedPlayer == Player.BOTH) return true;
		else if(affectedPlayer == Player.BROTHER && affectedPlayerObject.name == "Brother") return true;
		else if(affectedPlayer == Player.SISTER && affectedPlayerObject.name == "Sister") return true;
		return false;
	}
	
	public void SetPlayer(GameObject playerObject){
		affectedPlayerObject = playerObject;
	}
	
	public abstract void ApplyPowerup();
	public abstract void RemovePowerup();
}
