using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_script : MonoBehaviour {

    public GameObject player;
    public GameObject border_l;
    public GameObject border_r;
    public GameObject border_u;
    public GameObject border_d;

    private bool gameOver;
    private BoxCollider2D player_collider;
    private Rigidbody2D my_rb;
    private Rigidbody2D player_rb;
    private Vector3 offset;
    // Use this for initialization
    void Start()
    {
        gameOver = false;
        player_collider = player.GetComponent<BoxCollider2D>();
        player_rb = player.GetComponent<Rigidbody2D>();
        my_rb = GetComponent<Rigidbody2D>();
        offset = new Vector3(-0.1f, 0.4f, -10.0f);
        transform.position = player.transform.position + offset;
        //Debug.Log(offset);
    }
	// Update is called once per frame
	void LateUpdate () {
        /*
         * discarded code below
         *
        if (border_l.GetComponent<BoxCollider2D>().
            IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            my_rb.velocity = new Vector2(player_rb.velocity.x, 0.0f);
        }
        if (border_r.GetComponent<BoxCollider2D>().
            IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            my_rb.velocity = new Vector2(player_rb.velocity.x, 0.0f);
        }
        if (border_u.GetComponent<BoxCollider2D>().
            IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            my_rb.velocity = new Vector2(0.0f, player_rb.velocity.y);
        }
        if (border_d.GetComponent<BoxCollider2D>().
            IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            my_rb.velocity = new Vector2(0.0f, player_rb.velocity.y);
        }
        */
        /*
        if (!(player_collider.IsTouchingLayers(LayerMask.GetMask("Camera Borders"))))
        {
            my_rb.velocity = Vector2.zero;
        }
        else
        {
            my_rb.velocity = player_rb.velocity; 
        }
        */
        if (!gameOver) {
            transform.position = player.transform.position + offset;
        }
        
    }
    void EndGame(){
        //transform.parent = orig_trans;
        gameOver = true;
        transform.position = new Vector3(-17.0f, 1.0f, 10.0f);
    }
}
