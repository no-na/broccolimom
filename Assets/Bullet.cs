using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Bullet : MonoBehaviour {

    public float bulletForce = 200.0f;

    void OnTriggerEnter2D (Collider2D target)
    {
        if (target.gameObject.tag == "FirePoint")
        {
            Vector2 me = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),
            CrossPlatformInputManager.GetAxis("Vertical"));

            GetComponent<Rigidbody2D>().AddForce(me * bulletForce);

        }
    }
}