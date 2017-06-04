using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( BoxCollider2D ))]
public class AttackSling : Attack {

    public GameObject bullet;
    public Transform firePoint;
    public GameObject character; // Player is the GameObject it follows
    public GameObject slingshot; // Player is the GameObject
    public float accel; //accel changes the speed at which it rotates(joystick)
    public int bulletSpeed;
    public bool stateSwitch = false;

    // Use this for initialization
    void Start ()
    {
		transform.GetComponent<SpriteRenderer>().color = Color.clear;
		transform.GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        BulletSpawn(firePoint);

        BulletShot(bullet, bulletSpeed, firePoint);

    }

    void BulletSpawn(Transform child)
    {
        child.localPosition = new Vector3(Input.GetAxisRaw("Horizontal2"),
            Input.GetAxisRaw("Vertical2"), accel * Time.deltaTime);
    }

    void BulletShot(GameObject projectile, int speed, Transform parent)
    {
        if (Input.GetButton("Fire2") && stateSwitch == false)
        {
            Instantiate(projectile, parent.position, parent.rotation);
            StartCoroutine(PreFire());
        }

        if (Input.GetButton("Fire2") && stateSwitch == false)
        {
            Instantiate(projectile, parent.position, parent.rotation);
            StartCoroutine(PreFire());
        }

    }

    IEnumerator PreFire()
    {
        if (stateSwitch == false)
        {
            yield return new WaitForSeconds(0.3f);
        }
        else if (stateSwitch == true)
        {
            yield return new WaitForSeconds(0.15f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
	{
		//something has collided with the monster

		if (other.gameObject.CompareTag ("Enemy")) {
			other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
		}
        else if (other.gameObject.name =="RapidFire")
        {
            StartCoroutine(RapidShot());
        }
    }
    IEnumerator RapidShot()
    {
        Debug.Log("Rapid Firing");
        Invoke("NormalShot", 2);
        stateSwitch = true;
        yield return 0;
    }

    void NormalShot()
    {
        stateSwitch = false;
        Debug.Log("Normal shot");
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
				0
			); 
		else
			transform.localPosition = new Vector3
			(
				Input.GetAxisRaw("Horizontal2")*-2,
				Input.GetAxisRaw("Vertical2")*2, 
				0
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
