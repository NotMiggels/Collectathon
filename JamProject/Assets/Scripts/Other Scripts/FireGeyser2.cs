using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGeyser2 : MonoBehaviour {
    private GameObject player;
    private BoxCollider2D myCollider;
    public bool damaged;
    public float dmg;
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
            player.SendMessage("TakeDMG", dmg);
            //attacking = false;
            //Debug.Log("player damaged");
        }
	}
}
