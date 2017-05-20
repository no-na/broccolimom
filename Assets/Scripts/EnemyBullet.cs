using UnityEngine;
using System.Collections;

public class EnemyBullet : MonoBehaviour {

    public float bulletForce = 200.0f;
    public Vector2 direction = Vector2.left;
    public float bulletLife = 2;
    public string playerTag;

    private Rigidbody2D rb2d;




    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();


        rb2d.velocity = direction * bulletForce;


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

    //player collision!
    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.gameObject.CompareTag (playerTag))
        {
            bulletLife = 0;
        }
    }
}