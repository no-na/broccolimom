using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( BoxCollider2D ))]
public class AttackShield : Attack {

    public GameObject character; // Player is the GameObject it follows
    public GameObject shield; // Player is the GameObject
    public float accel; //accel changes the speeed at which it rotates (joystick)
    public int health = 3;
    public bool reflective = false;

    // Use this for initialization
    void Start () {
		transform.GetComponent<SpriteRenderer>().color = Color.clear;
		transform.GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		print("TRIGGER");
		//something has collided with the monster

		if (other.gameObject.CompareTag ("Enemy"))
        {
			other.gameObject.GetComponent<Enemy>().TakeDamage(damage);

		}

        Debug.Log(other.gameObject.tag);
        GameManager g = GameObject.Find("GameManager").GetComponent<GameManager>();
        g.ShieldHealth(other);

    }
	
	public override void DoAttack()
	{
		transform.GetComponent<SpriteRenderer>().color = Color.white;
		transform.GetComponent<Collider2D>().enabled = true;

        StartCoroutine(Reflection());
	}

    IEnumerator Reflection()
    {
        Debug.Log("Reflective");
        Invoke("ReflectShield", .25f);
        reflective = true;
        yield return 0;
    }

    void ReflectShield()
    {
        reflective = false;
        Debug.Log("Shield Reflective");
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
				Input.GetAxisRaw("Horizontal")*2,
				Input.GetAxisRaw("Vertical")*2, 
				200 * Time.deltaTime
			); 
		else
			transform.localPosition = new Vector3
			(
				Input.GetAxisRaw("Horizontal")*-2,
				Input.GetAxisRaw("Vertical")*2, 
				200 * Time.deltaTime
			); 
			
		float rotation = 0f;
		if(Input.GetAxisRaw("Vertical") == 0)
			rotation = 0f;
		else if(Input.GetAxisRaw("Horizontal") == 0)
			rotation = 90f;
		else if(Input.GetAxisRaw("Horizontal") * Input.GetAxisRaw("Vertical") > 0)
			rotation = 45f;
		else
			rotation = 120f;
		transform.localEulerAngles = new Vector3(0f,0f,rotation);
	}
	
}
