﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouton_scr : MonoBehaviour {

	private master_script ms;
    private BoxCollider2D myCollider;
	public int sceneid;
	public int croutonid;
	public int finallevel;
	public int insidevolcano;
	// Use this for initialization
	void Start () {

		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		myCollider = GetComponent<BoxCollider2D>();
		
	}
	
	// Update is called once per frame
	

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			Debug.Log("HI");
			ms.croutonAdd(sceneid);
			if(insidevolcano == 1)
			{
				sceneid = 2;
			}
			if(finallevel == 1)
			{
				sceneid = 3;
			}
			ms.updatecrouton(sceneid, croutonid);
			Destroy(gameObject);
		}
	}
}
