using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_script : MonoBehaviour {
    private master_script ms;
    private GameObject player;
    private Scr_PlayerControl player_script;
    public string destination;
    private BoxCollider2D bc;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        player_script = player.GetComponent<Scr_PlayerControl>();
        bc = GetComponent<BoxCollider2D>();
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
    }
	
	// Update is called once per frame
	void Update () {
        if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            ms.setJellyHealth(player_script.health);
            SceneManager.LoadScene(destination);
        }
    }
}
