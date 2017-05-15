using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ShieldControl2 shield;
    public GameObject shieldObj;
    public SpriteRenderer shieldRen;



    void Start()
    {
        shield = GameObject.Find("Circle").GetComponent<ShieldControl2>();
        shieldRen = GameObject.Find("Circle").GetComponent<SpriteRenderer>();
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
        else if (shield.health == 0)
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
