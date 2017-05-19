using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( BoxCollider2D ))]
public class AttackSling : Attack {

    public GameObject Bullet;
    public Transform FirePoint;
    public GameObject character; // Player is the GameObject it follows
    public GameObject slingshot; // Player is the GameObject
    public float accel; //accel changes the speeed at which it rotates(joystick)
    public int BulletSpeed;

    // Use this for initialization
    void Start () {
		transform.GetComponent<SpriteRenderer>().color = Color.clear;
		transform.GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        bulletspawn(FirePoint);
        BulletShot(Bullet, BulletSpeed, FirePoint);

    }

    void bulletspawn(Transform child)
    {

        child.localPosition = new Vector3(Input.GetAxisRaw("Horizontal2"),
            Input.GetAxisRaw("Vertical2"), accel * Time.deltaTime);
    }

    void BulletShot(GameObject projectile, int Speed, Transform parent)
    {
        if (Input.GetButtonDown("Fire"))
        {
            Instantiate(projectile, parent.position, parent.rotation);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		//something has collided with the monster

		if (other.gameObject.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
		}
	}
	
	public override void DoAttack()
	{
		transform.GetComponent<SpriteRenderer>().color = Color.white;
		transform.GetComponent<Collider2D>().enabled = true;
	}
	
	public override void CancelAttack()
	{
		transform.GetComponent<SpriteRenderer>().color = Color.clear;
		transform.GetComponent<Collider2D>().enabled = false;
	}
	
	public override void Aim()
	{
		if (transform.parent.localScale.x > 0)
			transform.localPosition = new Vector3
			(
				Input.GetAxisRaw("Horizontal2")*2,
				Input.GetAxisRaw("Vertical2")*2, 
				200 * Time.deltaTime
			); 
		else
			transform.localPosition = new Vector3
			(
				Input.GetAxisRaw("Horizontal2")*-2,
				Input.GetAxisRaw("Vertical2")*2, 
				200 * Time.deltaTime
			); 
			
		float rotation = 0f;
		if(Input.GetAxisRaw("Vertical2") == 0)
			rotation = 0f;
		else if(Input.GetAxisRaw("Horizontal2") == 0)
			rotation = 90f;
		else if(Input.GetAxisRaw("Horizontal2") * Input.GetAxisRaw("Vertical2") > 0)
			rotation = 45f;
		else
			rotation = 120f;
		transform.localEulerAngles = new Vector3(0f,0f,rotation);
	}
}
