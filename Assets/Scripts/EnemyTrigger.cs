using System;
using System.Collections;
using UnityEngine;


public class EnemyTrigger : MonoBehaviour {

	public string playerTag;
	public Enemy toTrigger;
    public GameObject g;

    private Animator anim;

    private BoxCollider2D bc2d;

	void Start()
	{
        bc2d = GetComponent<BoxCollider2D>();
        bc2d.isTrigger = true;
        anim = GetComponent<Animator>();
        if (g != null)
        {
            g.SetActive(false);
        }
	}

	void Update()
	{
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag (playerTag)) {
            if (g != null)
            {
                g.SetActive(true);
            }
            toTrigger.Go();
        }


	}






}