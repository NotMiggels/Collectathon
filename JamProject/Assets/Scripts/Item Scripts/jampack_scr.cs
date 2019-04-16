using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jampack_scr : MonoBehaviour {

	private GameObject player;
    private BoxCollider2D myCollider;
	// Use this for initialization
	void Start () {
		myCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
		
	}

    //heal jelly on contact and then destroy the object	
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
		
			Destroy(gameObject);
		}
	}
}
