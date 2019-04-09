using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class scr_levelselection : MonoBehaviour {

	private master_script ms;
	private spawnlocationdata spawndata;
	public GameObject[] levellist; 
	public int sceneid;
	public string scenename;
	private GameObject player;
	private Scr_PlayerControl player_script;
	public Button[] buttonlist;

	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		player_script = player.GetComponent<Scr_PlayerControl>();

		spawndata = GameObject.FindGameObjectWithTag("Locdata").GetComponent<spawnlocationdata>();
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		for(int i = 0; i < levellist.Length; i++)
		{
			if(ms.checkpoints[sceneid][i] == 0)
			{
				levellist[i].SetActive(false);
			}
			else
			{
				levellist[i].SetActive(true);
			}
			buttonlist[i].onClick.AddListener(GoToLevel);
			
			//buttonlist[i].onClick.AddListener(() => GoToLevel(i));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GoToLevel(){
		
		int checkid =  int.Parse(EventSystem.current.currentSelectedGameObject.name);
		checkid -=1;
		Debug.Log(checkid);
		Vector2 [][] datalisty = spawndata.returndata();
		ms.setJellyHealth(player_script.health);
		ms.setJellyGauge(player_script.Ability_gauge());
		ms.set_definedSpawn(true);
		ms.setSpawnLocation(datalisty[sceneid][checkid].x, datalisty[sceneid][checkid].y);
        SceneManager.LoadScene(scenename);
    }
}
