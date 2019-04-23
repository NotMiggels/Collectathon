using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_lava : MonoBehaviour {

	private GameObject player;
    private BoxCollider2D myCollider;
    public float dmg;
    
	// Use this for initialization
	void Start () {
		myCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update () {
		if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && player != null )
        {
           
            player.SendMessage("TakeDMG", dmg);

            //attacking = false;
            //Debug.Log("player damaged");
        }
	}
}
