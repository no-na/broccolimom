using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AttackShield shield;
    public GameObject shieldObj;
    public SpriteRenderer shieldRen;



    void Start()
    {
        shield = GameObject.Find("Shield").GetComponent<AttackShield>();
        shieldRen = GameObject.Find("Shield").GetComponent<SpriteRenderer>();
        Debug.Log(shield);
        shieldObj = transform.gameObject;
    }

    public void ShieldHealth (Collider2D target)
    {
        
        Debug.Log(target.gameObject.tag);
        if (shield.health >= 1 && target.gameObject.tag == "Monster")
        {
            shield.health -= 1;
            Debug.Log(shield.health);
        }
        else if (shield.health >= 1 && target.gameObject.tag == "Projectile" && shield.reflective == true)
        {
            Debug.Log("bounce");
            float opp_force = 5;
            // Calculate angle between the collision and the shield
            var opp_direction = transform.position - target.transform.position;
            // We then get the opposite (-Vector3) and normalize it
            opp_direction.Normalize();
            // add force in the opposite direction and multiply it by force. 
            // This will push back the projectile
            target.GetComponent<Rigidbody>().AddForce(opp_direction * opp_force);
        }
        else if (shield.health < 1)
        {
            Debug.Log("Zero");

            StartCoroutine(Calling());
            Debug.Log("Yo");
            shield.health = 3;
        }
    }
    
    IEnumerator Calling()
    {
        Debug.Log("Coroutine");
        Invoke("ActivateShield", 2);
        shieldObj.SetActive(false);
        shieldRen.enabled = false;
        Debug.Log("Shield Inactive");
        yield return 0;
    }

    void ActivateShield()
    {
        
        shieldObj.SetActive(true);
        shieldRen.enabled = true;
        Debug.Log("Shield Active");
    }
}
