using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float bulletForce = 200.0f;

    void OnTriggerEnter2D (Collider2D target)
    {
        if (target.gameObject.tag == "FirePoint")
        {
            Vector2 me = new Vector2(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

            GetComponent<Rigidbody2D>().AddForce(me * bulletForce);

        }
    }
}