using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamBehavior : Enemy {

    private bool isActive = false;

    public GameObject target1;
    public GameObject target2;

    public float spitInterval;
    private float spitTimer;

    public GameObject spitPoint;
    

    public GameObject inkPrefab;

    // Use this for initialization
    void Start()
    {
        spitTimer = spitInterval;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Attack a = other.gameObject.GetComponent<MonoBehaviour>() as Attack;
        if (a != null)
        {

            TakeDamage(a.Damage());
        }

    }

    // Update is called once per frame
    void Update()
    {
        


            Vector2 aimPoint = (target1.transform.position + target2.transform.position) / 2;

            //rotate towards the aim point
            transform.up = aimPoint - (Vector2)transform.position;


            spitTimer -= Time.deltaTime;
            if (spitTimer <= 0)
            {
                spitTimer = spitInterval;
                Spit();
            }
        

    }


    void Spit()
    {

        //aim the mouth


        //create the inkbullet
        GameObject eb = Instantiate(inkPrefab, this.transform.position, new Quaternion());

        //figure out what the heck the angle is
        Vector2 spitAngle = spitPoint.transform.position - this.transform.position;
        spitAngle = spitAngle.normalized;

        EnemyBullet ebull = eb.GetComponent<EnemyBullet>();
        ebull.direction = spitAngle;

        //addforce
        //Rigidbody2D ebrb = eb.GetComponent<Rigidbody2D>();
    }
    
}