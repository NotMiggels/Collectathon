using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_fight_area_script : MonoBehaviour {
    private GameObject UI_manager;
    private BoxCollider2D myCollider;
    private bool player_in;
	// Use this for initialization
	void Start () {
        myCollider = gameObject.GetComponent<BoxCollider2D>();
        UI_manager = GameObject.FindGameObjectWithTag("UIManager");
	}
	
	// Update is called once per frame
	void Update () {
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && !player_in){
            player_in = true;
            UI_manager.GetComponent<UI_healthbar>().ShowBossHP();
        }
        else if(!(myCollider.IsTouchingLayers(LayerMask.GetMask("Player"))) && player_in){
            player_in = false;
            UI_manager.GetComponent<UI_healthbar>().HideBossHP();
        }
	}
}
