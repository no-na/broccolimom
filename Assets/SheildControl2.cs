using System;
using UnityEngine;

public class SheildControl2 : MonoBehaviour {

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
        
      /*  Vector2 moveVec = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical")); */

       
        

        transform.localPosition = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), accel * Time.deltaTime); 
        // this transforms around the object thats moving, based upon your joysticks position, should rotate accordingly

    }

}

