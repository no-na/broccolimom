using UnityEngine;
using System.Collections;

public class TransitionTitle : MonoBehaviour {
	
	public GameObject loadingAnimation;
	public GameObject mainMenu;
	
	public void ChangeToMenu(){
		loadingAnimation.SetActive(false);
		mainMenu.SetActive(true);
		gameObject.GetComponent<Animator>().Play("menu_bars_uncover");
	}
	
	public void GoAway(){
		gameObject.SetActive(false);
	}
	
	//Based on the time/progress, populate the room with characters and props.
	public void PopulateEvents(){
		
	}

	public void SetSelfInactive(){
		gameObject.SetActive(false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
