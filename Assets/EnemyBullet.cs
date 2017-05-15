using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class EnemyBullet : MonoBehaviour {

    public float bulletForce = 200.0f;
    public Vector2 direction = Vector2.left;
    public float bulletLife = 2;

    private Rigidbody2D rb2d;




    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();


        rb2d.AddForce(direction * bulletForce);


    }



    void Update()
    {
        bulletLife -= Time.deltaTime;


        if (bulletLife <= 0)
        {
            Destroy(this.gameOjbect);
        }


    }
}