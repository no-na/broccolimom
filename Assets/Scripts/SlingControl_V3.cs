using System;
using UnityEngine;
using System.Collections;

public class SlingControl_V3 : MonoBehaviour {

    public GameObject Bullet;
    public Transform FirePoint;
    public GameObject character; // Player is the GameeObject it follows
    public GameObject slingshot; // Player is the GameeObject it follows
    public float accel; //accel changes the speeed at which it rotates
    public int BulletSpeed;
	//Tom's additions
	public bool rapid = false;
	public bool scatter = false;

    void Start()
    {
        AssignParent(slingshot, character);
        
    }


    //yes

    void Update()
    {

        SlingMove();
        bulletspawn(FirePoint);
        BulletShot(Bullet, BulletSpeed, FirePoint);
        
    }

    void bulletspawn(Transform child)
    {

        child.localPosition = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), accel * Time.deltaTime);
    }

    void AssignParent(GameObject child, GameObject parent)
    {
        //this makes the player keep its local orientation rather than its global orientation.
        child.transform.parent = parent.transform;

    }

    void SlingMove()
    {




        // this transforms around the object thats moving, based upon your joysticks position, should rotate accordingly
        transform.localPosition = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), accel * Time.deltaTime);


    }

    void BulletShot(GameObject projectile, int Speed, Transform parent)
    { 
        if (Input.GetButtonDown("Fire"))
        {
            Instantiate(projectile, parent.position, parent.rotation);

            //projectile.transform.TransformDirection(new Vector3(0, 0, Speed));

        }
    }


}

