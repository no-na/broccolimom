using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SquidTrigger : MonoBehaviour {


    private SquidHead sqhd;
    private PunchTentacle pnchtnt;
    private ThrowTentacle thrwtnt;

    private bool isStarted = false;

    public string playerTag;


	// Use this for initialization
	void Start () {
        sqhd = GameObject.Find("SquidHead").GetComponent<SquidHead>();
        pnchtnt = GameObject.Find("PunchTentacle").GetComponent<PunchTentacle>();
        thrwtnt = GameObject.Find("ThrowTentacle").GetComponent<ThrowTentacle>();

        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isStarted)
        {
            if (other.gameObject.CompareTag(playerTag))
            {
                isStarted = true;
                sqhd.Go();
                pnchtnt.Go();
                thrwtnt.Go();
            }
        }
    }
}
