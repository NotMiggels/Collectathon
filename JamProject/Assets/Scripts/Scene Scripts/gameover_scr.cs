using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover_scr : MonoBehaviour {

	public Button continuebt;
    public Button backtovillagebt;
    public Button mainmenubt;
	public string destination;
	public float spawn_x;
	public float spawn_y;
	public bool pre_defined_spawn_location;
	private master_script ms;

	// Use this for initialization
	void Start () {

		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        continuebt.onClick.AddListener(GoContinue);
        backtovillagebt.onClick.AddListener(GoJelly);
        mainmenubt.onClick.AddListener(GoMainMenu);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void GoContinue(){

        SceneManager.LoadScene(destination);
    }

    void GoJelly(){
		
		ms.set_definedSpawn(pre_defined_spawn_location);
		ms.setSpawnLocation(spawn_x, spawn_y);
        SceneManager.LoadScene("Village");
    }
    void GoMainMenu(){
   		Debug.Log("yikers");
        SceneManager.LoadScene("TitleScreen");
    }
}
