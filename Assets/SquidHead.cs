using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidHead : MonoBehaviour {

    private bool isActive = false;

    public GameObject target1;
    public GameObject target2;

    public float spitInterval;
    private float spitTimer;

    private GameObject spitPoint;

    public GameObject inkPrefab;

    // Use this for initialization
    void Start()
    {
        spitPoint = GameObject.Find("SpitPoint");
        spitTimer = spitInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
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

    }

   
    void Spit()
    {

        //aim the mouth




        //create the inkbullet
        GameObject eb = Instantiate(inkPrefab, spitPoint.transform.position, new Quaternion());

        //addforce
        Rigidbody2D ebrb = eb.GetComponent<Rigidbody2D>(); 
    }

    public void Go()
    {
        isActive = true;
    }
}
