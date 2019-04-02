using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squash_sprite_script : MonoBehaviour {
    public GameObject squash;
    public GameObject ChaseTrigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void EndTaunting()
    {
        squash.SendMessage("EndTaunting");
        ChaseTrigger.SendMessage("EndChasing");
    }
}
