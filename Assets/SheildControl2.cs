using System;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class SheildControl2 : MonoBehaviour {

    public GameObject character; // Player is the GameeObject it follows
    public GameObject shield; // Player is the GameeObject it follows
    public float accel; //accel changes the speeed at which it rotates
    public static float health = 3;

    void Start()
    {
        shield = GameObject.Find("Circle");
    }

    void Update()
    {
        lall(character);
        SheildMove();
        
    }


    /*IEnumerator OnTriggerEnter2D(Collider2D target)
    {
        Debug.Log(target.gameObject.tag);
        if (health >= 1 && target.gameObject.tag == "Monster")
        {
            health -= 1;
            Debug.Log(health);
        }
        else if (health == 0)
        {
            Debug.Log("Zero");
            shield.SetActive(false);

            yield return new WaitForSeconds(2);
            Debug.Log("Yo");

            shield.SetActive(true);
            health = 3;
        }
    }*/


    void lall(GameObject newParent)
    {
        //Same as above, except this makes the player keep its local orientation rather than its global orientation.
        shield.transform.parent = newParent.transform;
    }

    void SheildMove()
    {    
        
        transform.localPosition = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"), accel * Time.deltaTime); 
        // this transforms around the object thats moving, based upon your joysticks position, should rotate accordingly

    }

}

