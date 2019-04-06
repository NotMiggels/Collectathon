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
	// Use this for initialization
	void Start () {
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
			checkid +=1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GoToLevel(){

        SceneManager.LoadScene(scenename);
    }
}
