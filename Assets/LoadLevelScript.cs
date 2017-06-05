using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelScript : MonoBehaviour {
	
	public void LoadLevel(int scene){
		SceneManager.LoadScene(scene);
	}
		

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
