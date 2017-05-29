using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchTentacle : MonoBehaviour {

    private bool isActive = false;

    private Rigidbody2D rb2d;

    //gameobjects for the two characters go here
    public GameObject target1;
    public GameObject target2;

    public float speed;

    public float punchInterval;
    private float punchTimer;

    public float punchLength;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        punchTimer = punchInterval;
    }

    void pullBack()
    {
        //Vector2 targetDest = new Vector2(5f, transform.position.y);
        //transform.position = Vector2.MoveTowards(transform.position, targetDest, speed * Time.deltaTime);
        rb2d.velocity = Vector2.right * speed;
        Debug.Log("Pulling back");
    }

    void Punch()
    {
        //position the shark
        //randomly pick one of the two targets
        GameObject playerTarget = null;

        while (playerTarget == null)
        {

            int ran = Random.Range(1, 2);
            if (ran == 1)
            {
                playerTarget = target1;
            }
            else
            {
                playerTarget = target2;
            }


        }

        //get in position
        transform.position = new Vector3(transform.position.x, playerTarget.transform.position.y, transform.position.z);

        


        //zoom.
        rb2d.velocity = Vector2.left * speed;

        //wait 1.5 seconds

        StartCoroutine(PauseTentacle(punchLength));


       // rb2d.velocity = Vector2.zero;
        

    }

    IEnumerator PauseTentacle(float seconds)
    {
        yield return new WaitForSeconds(seconds);
 
        pullBack();
    }


    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            punchTimer -= Time.deltaTime;

            if (punchTimer <= 0)
            {
                punchTimer = punchInterval;
                Punch();
            }
        }

    }
    public void Go()
    {
        isActive = true;
    }
}
