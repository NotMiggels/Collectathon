using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_flame_script : MonoBehaviour {
    private GameObject player;
    private BoxCollider2D myCollider;
    private float flash_interval;
    private float flash_countdown;
    private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        myCollider = gameObject.GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        flash_interval = 0.1f;
        flash_countdown = flash_interval;
        sr = gameObject.GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
    void Update()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            player.SendMessage("TakeDMG", 15);
        }
        flash_countdown -= Time.deltaTime;
        if(flash_countdown < 0){
            sr.flipY = !sr.flipY;
            flash_countdown = flash_interval;
        }
    }
}
