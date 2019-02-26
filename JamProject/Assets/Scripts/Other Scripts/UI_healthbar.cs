using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_healthbar : MonoBehaviour {

    public GameObject health_bar;
    private GameObject player;
    private Scr_PlayerControl player_script;
    private Slider actual_bar;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        player_script = player.GetComponent<Scr_PlayerControl>();
		actual_bar = health_bar.GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player_script = player.GetComponent<Scr_PlayerControl>();
        }
        actual_bar.value = player_script.health;
	}
}
