using UnityEngine;
using System.Collections;

public class EnemyBullet : Enemy {

    public float bulletForce = 200.0f;
    public Vector2 direction = Vector2.left;
    public float bulletLife = 2;
    public string playerTag;

    private Rigidbody2D rb2d;




    void Start()
    {
		eType = "EnemyBullet";

		this.gameObject.tag = "Enemy";
		this.gameObject.layer = 10;

		rb2d = GetComponent<Rigidbody2D>();

        rb2d.velocity = direction * bulletForce;
		rb2d.isKinematic = false;

    }



    void Update()
    {
        bulletLife -= Time.deltaTime;


        if (bulletLife <= 0)
        {
            Destroy(this.gameObject);
        }



        rb2d.velocity = direction * bulletForce;

    }

	void OnCollisionEnter2D(Collision2D other)
	{
		//ignore the collision w/ other enemies
		if (other.gameObject.tag == "Enemy") {
			Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
		}
	}
}