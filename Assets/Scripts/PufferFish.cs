using UnityEngine;
using System.Collections;

public class PufferFish : Enemy
{

    private bool isMoving = false;
    public bool direction = false;
    //true = rightwards motion; false = leftwards motion; defaults to leftwards

    private Rigidbody2D rb2d;

    public float tolerance = .8f;

    public EnemyBullet bulletPrefab;

    public GameObject trigger;
    public GameObject parent;

    //gameobjects for the two characters go here
    public GameObject target1;
    public GameObject target2;

    //how fast the monster moves
    public float speed;

    private Vector2 targetDest;
    private Vector2 targetDir;

    private GameObject[] bullets;
    private EnemyBullet[] ebs = new EnemyBullet[8];

    private float bobs = 2;
    private float bobTimer = 2;

    private bool bobDir = true;

    public string playerTag;

    void Start()
    {
        bullets = new GameObject[8];

        int i = 0;

        Transform[] childs = GetComponentsInChildren<Transform>();

        foreach (Transform child in childs)
        {
            if (child.name.Contains("pike"))
            {
                bullets[i] = child.gameObject;
                i++;
            }
        }

      //  bullets = GetComponentsInChildren<GameObject>();

        int index = 0;
        foreach (GameObject e in bullets)
        {
            EnemyBullet eb = e.GetComponent<EnemyBullet>();
            ebs[index] = eb;
            index++;
            e.SetActive(false);
        }
        eType = "PufferFish";
        health = 1;
        bobTimer = 0;
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.isKinematic = false;

    }

    void Update()
    {

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        if (isMoving)
        {

            if (target1 == null)
            {
                targetDest = target2.transform.position;
            }
            else if (target2 == null)
            {
                targetDest = target1.transform.position;
            }
            else
            {

                //locate target
                float x = (target1.transform.position.x + target2.transform.position.x) / 2f;
                float y = (target1.transform.position.y + target2.transform.position.y) / 2f;
                targetDest = new Vector2(x, y);
            }




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


        if (target1 == null)
        {
            targetDest = target2.transform.position;
        }
        else if (target2 == null)
        {
            targetDest = target1.transform.position;
        }
        else
        {

            //locate target
            float x = (target1.transform.position.x + target2.transform.position.x) / 2f;
            float y = (target1.transform.position.y + target2.transform.position.y) / 2f;
            targetDest = new Vector2(x, y);
        }


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

        foreach (GameObject g in bullets)
        {
            g.SetActive(true);
            g.transform.position = this.transform.position;
            g.transform.parent = null;
        }

        //create & fire bullets
        Vector2 bulletDir = Vector2.up;
        EnemyBullet eb = ebs[0];
        eb.direction = bulletDir;

        bulletDir = Vector2.down;
        eb = ebs[1];
        eb.direction = bulletDir;

        bulletDir = Vector2.left;
        eb = ebs[2];
        eb.direction = bulletDir;

        bulletDir = Vector2.right;
        eb = ebs[3];
        eb.direction = bulletDir;

        bulletDir = new Vector2(1, 1);
        eb = ebs[4];
        eb.direction = bulletDir;

        bulletDir = new Vector2(-1, -1);
        eb = ebs[5];
        eb.direction = bulletDir;

        bulletDir = new Vector2(-1, 1);
        eb = ebs[6];
        eb.direction = bulletDir;

        bulletDir = new Vector2(1, -1);
        eb = ebs[7];
        eb.direction = bulletDir;

        Destroy(trigger);
        Destroy(parent);
        Destroy(this.gameObject, 3f);


    }

    //collision
    void OnCollisionEnter2D(Collision2D other)
    {
        //ignore the collision w/ player or other enemies
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "Platform")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>());
        }
    }
}
