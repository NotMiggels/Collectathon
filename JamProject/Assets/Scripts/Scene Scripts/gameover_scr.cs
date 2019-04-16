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
	private spawnlocationdata spawndata;
	private Scr_PlayerControl player_script;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		player_script = player.GetComponent<Scr_PlayerControl>();
		spawndata = GameObject.FindGameObjectWithTag("Locdata").GetComponent<spawnlocationdata>();
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        continuebt.onClick.AddListener(GoContinue);
        backtovillagebt.onClick.AddListener(GoJelly);
        mainmenubt.onClick.AddListener(GoMainMenu);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Have to respawn from last checkpoint/spawn point
	void GoContinue(){
		int sceneid = ms.lastscene;
		int checkid = ms.lastcheckpoint;
		Vector2 [][] datalisty = spawndata.returndata();
		ms.setJellyHealth(100);
		ms.setJellyGauge(1);
		ms.set_definedSpawn(true);
		ms.setSpawnLocation(datalisty[sceneid][checkid].x, datalisty[sceneid][checkid].y);
		if(sceneid == 0)
		{
			destination = "JungleScene";
		}
		else if (sceneid == 1)
		{
			destination = "VolcanoScene";
		}
		else if (sceneid == 2)
		{
			destination = "insideVolcanoScene";
		}
		else
		{
			destination = "FinalLevel";
		}
        SceneManager.LoadScene(destination);
    }

	//Go back to village
    void GoJelly(){
		ms.setJellyHealth(100);
		ms.setJellyGauge(1);
		ms.set_definedSpawn(true);
		ms.setSpawnLocation(-11.89f,.454f);
        SceneManager.LoadScene("Village");
    }

	//Just move back to TitleScreen
    void GoMainMenu(){
        SceneManager.LoadScene("TitleScreen");
    }
}
