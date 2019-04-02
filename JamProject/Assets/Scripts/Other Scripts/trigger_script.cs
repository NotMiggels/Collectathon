using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_script : MonoBehaviour {
    //private GameObject player;
    //public string enemy_tag;
    //private GameObject[] enemies;
    private BoxCollider2D bc;
    private bool player_inside;
    private int enemy_count;
    private float escape_countdown;
    private bool chasing;
	// Use this for initialization
	void Start () {
        //player = GameObject.FindWithTag("Player");
        //enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        //enemy_count = enemies.Length;
        chasing = false;
        escape_countdown = 2.0f;
        bc = GetComponent<BoxCollider2D>();
        player_inside = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bc.IsTouchingLayers(LayerMask.GetMask("Player")) && !chasing)
        {
            chasing = true;
            escape_countdown = 2.0f;
            //player_inside = true;
            SendMessageUpwards("ChasePlayer", GameObject.FindWithTag("Player"));
        }
        
        if(chasing && !bc.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            escape_countdown -= Time.deltaTime;
            //player_inside = false;
        }
        else if(chasing && bc.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            escape_countdown = 2.0f;
        }
        if(escape_countdown < 0)
        {
            //player_inside = false;
            escape_countdown = 2.0f;
            chasing = false;
            SendMessageUpwards("Idle");
        }
    }
    void EnemyDecrement(){
        enemy_count -= 1;
    }
    public void EndChasing()
    {
        chasing = false;
    }
}
