using System;
using System.Collections;
using UnityEngine;


public class EnemyTrigger : MonoBehaviour {

	public string playerTag;
	public Enemy toTrigger;

    private BoxCollider2D bc2d;

	void Start()
	{
        bc2d = GetComponent<BoxCollider2D>();
        bc2d.isTrigger = true;
	}

	void Update()
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag (playerTag)) {
            toTrigger.Go();
		}


	}






}