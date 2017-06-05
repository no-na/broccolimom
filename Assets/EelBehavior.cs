using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelBehavior : Enemy {
    private bool isActive = false;

    public GameObject target;

    public float spitInterval;
    private float spitTimer;

    private bool isSpitting = false;
    public Animator anim;

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

    public override void Go()
    {
        isSpitting = true;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 aimPoint = target.transform.position;

        //rotate towards the aim point
        transform.up = aimPoint - (Vector2)transform.position;

        if (isSpitting)
        {



            spitTimer -= Time.deltaTime;
            if (spitTimer <= 0)
            {
                spitTimer = spitInterval;
                Spit();
            }
        }

    }


    void Spit()
    {

        //aim the mouth

        anim.SetTrigger("attack");
        //create the inkbullet
        GameObject eb = Instantiate(inkPrefab, this.transform.position, new Quaternion());

        //figure out what the heck the angle is
        Vector2 spitAngle = spitPoint.transform.position - this.transform.position;
        spitAngle = spitAngle.normalized;

        EnemyBullet ebull = eb.GetComponent<EnemyBullet>();
        ebull.direction = spitAngle;
    }

}