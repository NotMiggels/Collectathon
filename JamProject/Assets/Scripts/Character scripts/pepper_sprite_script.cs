using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepper_sprite_script : MonoBehaviour {
    public GameObject pepper;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Attack(){
        pepper.SendMessage("Attack");
    }
}
