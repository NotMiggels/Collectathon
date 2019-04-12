using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouton_loading_scr : MonoBehaviour {
	public GameObject[] crouton_list;
	private master_script ms;
	public int sceneid;
	// Use this for initialization
	void Start () {
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		for(int i = 0; i < 50; i ++)
		{
			if(ms.crouton[sceneid][i] == 1)
			{
				crouton_list[i].SetActive(false);
			}
			else
			{
				crouton_list[i].SetActive(true);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
