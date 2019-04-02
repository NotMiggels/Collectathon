using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana_sprite_script : MonoBehaviour {
    public GameObject banana;
    public GameObject ChaseTrigger;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void EndTaunting()
    {
        banana.SendMessage("EndTaunting");
        ChaseTrigger.SendMessage("EndChasing");
    }
}
