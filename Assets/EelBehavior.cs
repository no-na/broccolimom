﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelBehavior : MonoBehaviour {
    private bool isActive = false;

    public GameObject target;

    public float spitInterval;
    private float spitTimer;

    public GameObject spitPoint;

    public GameObject inkPrefab;

    // Use this for initialization
    void Start()
    {
        spitTimer = spitInterval;
    }

    // Update is called once per frame
    void Update()
    {
         


        Vector2 aimPoint = target.transform.position;

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
    }

}