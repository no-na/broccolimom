using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float bulletForce = 200.0f;
	public float bulletLife = 2;
	public string enemyTag;
	
	private Vector2 me;
	private Rigidbody2D rb2d;
	private int damage = 4;
	
	
	void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		me = new Vector2(Input.GetAxisRaw("Horizontal2"),
        Input.GetAxisRaw("Vertical2"));
		
		if( me.x == 0 && me.y == 0)
		{
			me = new Vector2(1,0);
		}


        rb2d.velocity = me * bulletForce;


    }
	
    void Update()
    {
        bulletLife -= Time.deltaTime;
		rb2d.velocity = me * bulletForce;


        if (bulletLife <= 0)
        {
            Destroy(this.gameObject);
        }



        

    }

    //player collision!
    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			if(other.gameObject.GetComponent<Enemy>()..EventType != "EnemyBullet" || other.gameObject.layer != "Trigger")
			{
				print ("bullet collision");
				bulletLife = 0;
				other.gameObject.GetComponent<Enemy> ().TakeDamage (damage);
			}
		}
    }
}