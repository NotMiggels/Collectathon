using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crispyrequirements : MonoBehaviour {

	public GameObject elevator;
	private master_script ms;
	private bool triggeronce;
	
	// Use this for initialization
	void Start () {
		triggeronce = false;
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();	
		elevator.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(ms.getCT() < 10)
		{
			elevator.SetActive(false);
		}
		else
		{
			if(triggeronce == false)
			{
				triggeronce = true;
				elevator.SetActive(true);
				MovingPlatformScript scripty =  elevator.GetComponent<MovingPlatformScript>();	
				StartCoroutine(scripty.movingtime(-1, 10));	
			}	
		}
		
	}
}
