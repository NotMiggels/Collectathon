using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_menu_script : MonoBehaviour {
    public Button testing1;
    public Text text;
    private master_script ms;
	// Use this for initialization
	void Start () {
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        testing1.onClick.AddListener(GoTesting1);
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Crispy toasts: " + ms.getCT();
	}  
    void GoTesting1(){
        SceneManager.LoadScene("JungleScene");
    }
}
