using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squid_boss : MonoBehaviour {

    public float health;

    public GameObject rockprefab;

    private int attackAnim;
    public float attackTime = 3;
    private float attackTimer;

    public Animator anim;

    public GameObject target1;
    public GameObject target2;

    public BoxCollider2D top;
    public BoxCollider2D mid;
    public BoxCollider2D bot;

    public GameObject throwpoint;

	// Use this for initialization
	void Start () {
        attackTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (attackTimer <= 0)
        {
            pickAttack();
            attackTimer = attackTime;
        }
        else
        {
            attackTimer -= Time.deltaTime;
        }

        //keep the throwpoint rotated
        Vector2 aimPoint = Vector2.zero;

        if (target1 == null)
        {
            aimPoint = target2.transform.position;
        }
        else if (target2 == null)
        {
            aimPoint = target1.transform.position;
        }
        else
        {

            aimPoint = (target1.transform.position + target2.transform.position) / 2;
        }

        //rotate towards the aim point
        throwpoint.transform.up = aimPoint - (Vector2)throwpoint.transform.position;


    }

    void TakeDamage(int amt)
    {
        health -= amt;

        if (health <= 0)
            Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collision2D other)
    {
        //check other's type
        Attack a = other.gameObject.GetComponent<MonoBehaviour>() as Attack;
        if (a != null)
        {

            TakeDamage(a.Damage());
        }

    }


    void pickAttack()
    {
    }

    void PunchAttack()
    {

    }

    void throwRock(int level)
    {
        //create a new rock prefab
        GameObject currRock = Instantiate(rockprefab, throwpoint.transform.position, new Quaternion());

        Vector2 spitAngle = throwpoint.transform.up;

        EnemyBullet ebull = currRock.GetComponent<EnemyBullet>();
        ebull.direction = spitAngle;


    }
}
