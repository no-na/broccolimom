using System;
using System.Collections;
using UnityEngine;


public class EnemyTrigger : MonoBehaviour {

	public string playerTag;
	public GameObject toTrigger;

	void Start()
	{
	}

	void Update()
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag (playerTag)) {
			toTrigger.setActive(true);
		}


	}






}