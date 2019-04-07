using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class scr_levelselection : MonoBehaviour {

	private master_script ms;
	public GameObject[] levellist; 
	public int sceneid;
	public string scenename;
	//private GameObject player;
	//private Scr_PlayerControl player_script;
	public Button[] buttonlist;

	
	// Use this for initialization
	void Start () {
		//player = GameObject.FindGameObjectWithTag("Player");
		//player_script = player.GetComponent<Scr_PlayerControl>();
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		int checkid = 0;
		for(int i = 0; i < levellist.Length; i++)
		{
			if(ms.checkpoints[sceneid][checkid] == 0)
			{
				levellist[i].SetActive(false);
			}
			else
			{
				levellist[i].SetActive(true);
			}
			buttonlist[i].onClick.AddListener(GoToLevel);
			checkid +=1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GoToLevel(){
		//ms.setJellyHealth(player_script.health);
		//ms.setJellyGauge(player_script.Ability_gauge());
		//ms.set_definedSpawn(true);
		//ms.setSpawnLocation(spawn_x, spawn_y);
        SceneManager.LoadScene(scenename);
    }
}
