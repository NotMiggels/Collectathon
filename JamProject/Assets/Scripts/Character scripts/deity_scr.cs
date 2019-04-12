using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deity_scr : MonoBehaviour {

	private master_script ms;
	// Use this for initialization
	void Start () 
	{
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		int ctcount = ms.getCT();
		float inty = (float)(ctcount + 1)/21;
		Debug.Log(inty);
		gameObject.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f, inty);

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	
}
