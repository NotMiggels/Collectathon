using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_script : MonoBehaviour {
    //private GameObject player;
    public string enemy_tag;
    private GameObject[] enemies;
    private BoxCollider2D bc;
    private bool player_inside; 
	// Use this for initialization
	void Start () {
        //player = GameObject.FindWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        bc = GetComponent<BoxCollider2D>();
        player_inside = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            player_inside = true;
            foreach (GameObject enemy in enemies)
            {
                enemy.SendMessage("ChasePlayer", GameObject.FindWithTag("Player"));
            }
        }
        if(player_inside && !(bc.IsTouchingLayers(LayerMask.GetMask("Player"))))
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.SendMessage("Idle");
            }
        }
    }
}
