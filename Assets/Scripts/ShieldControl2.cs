using System;
using System.Collections;
using UnityEngine;



public class ShieldControl2 : MonoBehaviour {

    public GameObject character; // Player is the GameeObject it follows
    public GameObject shield; // Player is the GameeObject it follows
    public float accel; //accel changes the speeed at which it rotates
    public int health = 3;

    void Start()
    {
        //shield = GameObject.Find("Circle");
    }

    void Update()
    {
        lall(character);
        SheildMove();
        
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log(target.gameObject.tag);
        GameManager g = GameObject.Find("GameManager").GetComponent<GameManager>();
        g.ShieldHealth(target);
    }


    void lall(GameObject newParent)
    {
        //Same as above, except this makes the player keep its local orientation rather than its global orientation.
        shield.transform.parent = newParent.transform;
    }

    void SheildMove()
    {    
        
        transform.localPosition = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), accel * Time.deltaTime); 
        // this transforms around the object thats moving, based upon your joysticks position, should rotate accordingly

    }

}

