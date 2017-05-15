using UnityEngine;
using System.Collections;

public class PufferFish : Enemy {


	public bool direction = false;
	//true = rightwards motion; false = leftwards motion; defaults to leftwards

	private Rigidbody2D rb2d;

    public EnemyBullet bulletPrefab;

	//gameobjects for the two characters go here
	public GameObject target1;
	public GameObject target2;

	//how fast the monster moves
	public float speed;

	private Vector2 targetDest;
	private Vector2 targetDir;

	private float bobs = 2;
	private float bobTimer =2;

	private bool bobDir = true;
	
	void Start()
	{
        
		bobTimer = 0;
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{

		if (health <= 0) {
			Destroy (this.gameObject);
		}
        

        //locate target
        float x = (target1.transform.position.x - target2.transform.position.x) / 2f;
        float y = (target1.transform.position.y - target2.transform.position.y) / 2f;
        targetDest = new Vector2(x, y);


        //find direction

        //this code taken from the unity manual
        Vector2 heading = (new Vector2(x,y) - (Vector2)this.transform.position);
        float distance = heading.magnitude;
        Vector2 direction = heading / distance; // This is now the normalized direction.

        rb2d.velocity = direction * speed;



    }

	public void TakeDamage(int damage)
	{
		health -= damage;
	}

    void Attack()
    {
        //attack cue, code, etc. goes here

        //create & fire bullets
        Vector2 bulletDir = Vector2.up;
        EnemyBullet eb = Instantiate(bulletPrefab);
        eb.direction = bulletDir;

        bulletDir = Vector2.up;
        eb = Instantiate(bulletPrefab);
        eb.direction = bulletDir;

        bulletDir = Vector2.left;
        eb = Instantiate(bulletPrefab);
        eb.direction = bulletDir;

        bulletDir = Vector2.right;
        eb = Instantiate(bulletPrefab);
        eb.direction = bulletDir;

        bulletDir = new Vector2(1, 1);
        eb = Instantiate(bulletPrefab);
        eb.direction = bulletDir;

        bulletDir = new Vector2(-1, -1);
        eb = Instantiate(bulletPrefab);
        eb.direction = bulletDir;

        bulletDir = new Vector2(-1, 1);
        eb = Instantiate(bulletPrefab);
        eb.direction = bulletDir;

        bulletDir = new Vector2(1, -1);
        eb = Instantiate(bulletPrefab);
        eb.direction = bulletDir;


    }
}
