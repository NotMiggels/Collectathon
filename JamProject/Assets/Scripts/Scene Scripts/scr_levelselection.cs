using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_levelselection : MonoBehaviour {

	private master_script ms;
	public GameObject[] levellist;
	public int sceneid;
	// Use this for initialization
	void Start () {
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		int checkid = 0;
		foreach (GameObject bt in levellist)
		{
			if(ms.checkpoints[sceneid][checkid] == 0)
			{
				bt.SetActive(false);
			}
			else
			{
				bt.SetActive(true);
			}
			checkid +=1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
