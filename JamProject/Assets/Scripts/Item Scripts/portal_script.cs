using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_script : MonoBehaviour
{
    private master_script ms;
    private GameObject player;
    private Scr_PlayerControl player_script;
    public string destination;
    public float spawn_x;
    public float spawn_y;
    public bool pre_defined_spawn_location;
    private BoxCollider2D bc;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_script = player.GetComponent<Scr_PlayerControl>();
        bc = GetComponent<BoxCollider2D>();
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            ms.setJellyHealth(player_script.health);
            ms.setJellyGauge(player_script.Ability_gauge());
            ms.set_definedSpawn(pre_defined_spawn_location);
            ms.setSpawnLocation(spawn_x, spawn_y);
            SceneManager.LoadScene(destination);
        }
    }
}
