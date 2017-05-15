using System;
using UnityEngine;

public class SheildControl : MonoBehaviour {

    public GameObject character; // Player is the GameeObject it follows
    public GameObject sheild; // Player is the GameeObject it follows
    public float accel; //accel changes the speeed at which it rotates

    void Start()
    {
       
    }

    void Update()
    {
        lall(character);
        SheildMove();
        
    }

    void lall(GameObject newParent)
    {
        //Same as above, except this makes the player keep its local orientation rather than its global orientation.
        sheild.transform.parent = newParent.transform;
    }

    void SheildMove()
    {
        
        Vector3 moveVec = new Vector3(
			transform.rotation.x,
			Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        transform.RotateAround(transform.parent.position, moveVec, accel * Time.deltaTime); 
        // this transforms around the object thats moving, based upon your joysticks position, should rotate accordingly

    }

}

