using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_healthbar : MonoBehaviour {

    public GameObject health_bar;
    public GameObject gauge_bar;
    public Text ability_text;
    private GameObject player;
    private Scr_PlayerControl player_script;
    private Slider actual_bar;
    private Slider actual_gauge;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        player_script = player.GetComponent<Scr_PlayerControl>();
		actual_bar = health_bar.GetComponent<Slider>();
        actual_gauge = gauge_bar.GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update () {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player_script = player.GetComponent<Scr_PlayerControl>();
        }
        actual_bar.value = player_script.health;
        actual_gauge.value = player_script.Ability_gauge();
	}
    void SetAbilityText(int num)
    {
        ability_text.text = "Ability #" + num;
    }
}
