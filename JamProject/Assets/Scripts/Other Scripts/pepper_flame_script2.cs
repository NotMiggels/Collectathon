using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepper_flame_script2 : MonoBehaviour {
    private GameObject player;
    private BoxCollider2D myCollider;
    private bool damaged;
	// Use this for initialization
	void Start () {
        myCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        damaged = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && player != null && !damaged)
        {
            damaged = true;
            player.SendMessage("TakeDMG", 15);
            //attacking = false;
            //Debug.Log("player damaged");
        }
	}
}
