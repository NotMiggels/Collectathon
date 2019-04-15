using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jelly_sprite_script : MonoBehaviour {
    public GameObject jelly;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void EndCelebrating(){
        jelly.SendMessage("EndCelebration");
    }
}
