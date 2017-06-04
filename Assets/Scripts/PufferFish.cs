using UnityEngine;
using System.Collections;

public class PufferFish : Enemy {

    private bool isMoving = false;
	public bool direction = false;
	//true = rightwards motion; false = leftwards motion; defaults to leftwards

	private Rigidbody2D rb2d;

    private float tolerance = .2f;

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

    public string playerTag;

	void Start()
	{
		eType = "PufferFish";
		health = 1;
		bobTimer = 0;
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.isKinematic = false;

	}

	void Update()
	{

		if (health <= 0) {
			Destroy (this.gameObject);
		}

        if (isMoving)
        {
            //locate target
            float x = (target1.transform.position.x + target2.transform.position.x) / 2f;
            float y = (target1.transform.position.y + target2.transform.position.y) / 2f;
            targetDest = new Vector2(x, y);


            //find direction

            //this code taken from the unity manual
            //Vector2 heading = new Vector2();
            //heading.x = this.transform.position.x - x;
            //heading.y = this.transform.position.y - y;
            //heading.x = -heading.x;
            //heading.y = -heading.y;
            //float distance = heading.magnitude;
            //Vector2 direction = heading / distance; // This is now the normalized direction.



            transform.position = Vector2.MoveTowards(transform.position, targetDest, speed * Time.deltaTime);


           // rb2d.velocity = direction * speed;
        }

        //calculate distance to midpoint; if within a certain tolerance, attack
        float distance = Vector2.Distance(transform.position, targetDest);
        if (distance < tolerance)
        {
            Attack();
        }

    }

	public void TakeDamage(int damage)
	{
		health -= damage;
	}

    public override void Go()
    {
        isMoving = true;

        //locate target
        float x = (target1.transform.position.x + target2.transform.position.x) / 2f;
        float y = (target1.transform.position.y + target2.transform.position.y) / 2f;
        targetDest = new Vector2(x, y);


        //move towards midpoint

        transform.position = Vector2.MoveTowards(transform.position, targetDest, speed * Time.deltaTime);

        //rb2d.velocity = direction * speed;


    }

    //this needs to betestedand will likely need to be rewritten
    void OnTriggerEnter2D(Collider2D other)
    {
        Attack a = other.gameObject.GetComponent<MonoBehaviour>() as Attack;
        if (a != null)
        {

            TakeDamage(a.Damage());
        }

    }

    void Attack()
    {
        //attack cue, code, etc. goes here

        //create & fire bullets
        Vector2 bulletDir = Vector2.up;
        EnemyBullet eb = Instantiate(bulletPrefab,this.transform.transform.position, new Quaternion());
        eb.direction = bulletDir;

        bulletDir = Vector2.down;
        eb = Instantiate(bulletPrefab, this.transform.transform.position, new Quaternion());
        eb.direction = bulletDir;

        bulletDir = Vector2.left;
        eb = Instantiate(bulletPrefab, this.transform.transform.position, new Quaternion());
        eb.direction = bulletDir;

        bulletDir = Vector2.right;
        eb = Instantiate(bulletPrefab, this.transform.transform.position, new Quaternion());
        eb.direction = bulletDir;

        bulletDir = new Vector2(1, 1);
        eb = Instantiate(bulletPrefab, this.transform.transform.position, new Quaternion());
        eb.direction = bulletDir;

        bulletDir = new Vector2(-1, -1);
        eb = Instantiate(bulletPrefab, this.transform.transform.position, new Quaternion());
        eb.direction = bulletDir;

        bulletDir = new Vector2(-1, 1);
        eb = Instantiate(bulletPrefab, this.transform.transform.position, new Quaternion());
        eb.direction = bulletDir;

        bulletDir = new Vector2(1, -1);
        eb = Instantiate(bulletPrefab, this.transform.transform.position, new Quaternion());
        eb.direction = bulletDir;

        Destroy(this.gameObject);


    }

    //collision
	void OnCollisionEnter2D(Collision2D other)
	{
		//ignore the collision w/ player or other enemies
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") {
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
		}
	}
}
