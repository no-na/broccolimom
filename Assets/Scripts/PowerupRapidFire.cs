using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRapidFire : Powerup {
	private AttackSling playerAttack; //This powerup affects attack speed, so we need to know the player's Attack class.
	private SpriteRenderer playerSpriteRenderer;
	[SerializeField]
	private float bulletDelay = 0.15f; //The bullet delay while the powerup is active
	private float originalBulletDelay = 0.3f; //This will store the original bullet delay to restore once the powerup is removed.

	public override void ApplyPowerup(){
		playerAttack = affectedPlayerObject.transform.GetChild(0).GetComponent<AttackSling>();
		playerSpriteRenderer = affectedPlayerObject.GetComponent<SpriteRenderer>();
		//originalBulletDelay = playerAttack.GetBulletDelay();
		playerAttack.SetBulletDelay(bulletDelay);
		playerSpriteRenderer.color = Color.green;
	}
	
	public override void RemovePowerup(){
		playerAttack.SetBulletDelay(originalBulletDelay);
		playerSpriteRenderer.color = Color.white;
	}
}
