using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy s = other.gameObject.GetComponent<Enemy>();
        if (s != null)
        {

            Destroy(other.gameObject);

        }
        EnemyBullet eb = other.gameObject.GetComponent<EnemyBullet>();
        if (eb != null)
        {

            Destroy(other.gameObject);

        }
    }
}
