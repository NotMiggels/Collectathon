using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_script : MonoBehaviour {
    //private GameObject player;
    public string enemy_tag;
    private GameObject[] enemies;
    private BoxCollider2D bc;
    private bool player_inside;
    private int enemy_count;
	// Use this for initialization
	void Start () {
        //player = GameObject.FindWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag(enemy_tag);
        enemy_count = enemies.Length;
        bc = GetComponent<BoxCollider2D>();
        player_inside = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            player_inside = true;
            if (enemy_count > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    enemy.SendMessage("ChasePlayer", GameObject.FindWithTag("Player"));
                }
            }
        }
        if(player_inside && !(bc.IsTouchingLayers(LayerMask.GetMask("Player"))))
        {
            if (enemy_count > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    enemy.SendMessage("Idle");
                }
            }
        }
    }
    void EnemyDecrement(){
        enemy_count -= 1;
    }
}
