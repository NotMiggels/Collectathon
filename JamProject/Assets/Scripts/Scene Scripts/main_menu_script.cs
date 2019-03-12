using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class main_menu_script : MonoBehaviour {
    public Button testing1;
    public Button jungle;

    public Button volcano;

    public Button finallevel;
    
    public Text text;
    private master_script ms;
	// Use this for initialization
	void Start () {
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        testing1.onClick.AddListener(GoTesting1);
        jungle.onClick.AddListener(GoJungle);
        volcano.onClick.AddListener(GoVolcano);
        finallevel.onClick.AddListener(GoFinalLevel);
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Crispy toasts: " + ms.getCT();
	}  
    void GoTesting1(){
        SceneManager.LoadScene("Testing1");
    }
    void GoJungle(){
        SceneManager.LoadScene("Village");
    }

    void GoVolcano(){
        SceneManager.LoadScene("VolcanoScene");
    }
    void GoFinalLevel(){
        SceneManager.LoadScene("FinalLevel");
    }
}
