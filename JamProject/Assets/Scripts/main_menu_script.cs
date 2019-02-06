using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_menu_script : MonoBehaviour {
    public Button testing1;
	// Use this for initialization
	void Start () {
        testing1.onClick.AddListener(GoTesting1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}  
    void GoTesting1(){
        SceneManager.LoadScene("Testing1");
    }
}
