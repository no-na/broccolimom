using System;
using System.Collections;
using UnityEngine;


public class EnemyTrigger : MonoBehaviour {

	[SerializeField]
	private string playerTag = "Player";
	[SerializeField]
	private GameObject enemyGroup;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag (playerTag)) {
			enemyGroup.SetActive(true);
		}
	}
}