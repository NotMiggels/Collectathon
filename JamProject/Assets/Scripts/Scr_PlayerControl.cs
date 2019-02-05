using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerControl : MonoBehaviour {


    public float top_spd; //1
    public float jump_velo; //20
    public float accel; //.45
    public float brake_drag; //10
    public GameObject sprite;
    //public GameObject hitbox;
    private bool playerMoving;
    private Vector2 lastMove;

    private Animator anim;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myCollider;
    private bool in_air;
    private bool W_pressed;
    private float orig_drag;
    private bool moving_anim_playing;
    private bool attack_anim_playing;
    private bool shielding;
    private SpriteRenderer sr;
   

    // Use this for initialization
    void Start () {
        in_air = true;
        W_pressed = false;
        anim = sprite.GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myRigidbody.freezeRotation = true;
        sr = sprite.GetComponent<SpriteRenderer>();
        moving_anim_playing = false;
        attack_anim_playing = false;
        shielding = false;
    }
	
	// Update is called once per frame
	void Update () {
        /*
        playerMoving = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
            playerMoving = true;
            lastMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        */
        //playerMoving = false;

        if(in_air && (myCollider.IsTouchingLayers(LayerMask.GetMask("Obstacles")) ||
            myCollider.IsTouchingLayers(LayerMask.GetMask("Platform"))))
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.0f);
        }
        in_air = !(myCollider.IsTouchingLayers(LayerMask.GetMask("Obstacles")) ||
            myCollider.IsTouchingLayers(LayerMask.GetMask("Platform")));
       
        
        //Debug.Log(in_air);
        if (Input.GetKey(KeyCode.W) && !in_air && !W_pressed && !shielding)
        {
            W_pressed = true;
            myRigidbody.AddForce(new Vector2(0.0f, jump_velo));
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            W_pressed = false;
        }
        if (Input.GetKey(KeyCode.A) && (myRigidbody.velocity.x) > top_spd*-1.0f && !shielding)
        {
            myRigidbody.AddForce(new Vector2(accel*-1.0f, 0.0f));
        }
        if (Input.GetKey(KeyCode.D) && (myRigidbody.velocity.x) < top_spd && !shielding)
        {
            myRigidbody.AddForce(new Vector2(accel, 0.0f));
        }
        if (Input.GetKey(KeyCode.S) && !in_air && myRigidbody.velocity.magnitude > 0.0f && !shielding)
        {
            //orig_drag = myRigidbody.drag;
            myRigidbody.drag = brake_drag; 
        }
        if (Input.GetKeyUp(KeyCode.S) && !in_air)
        {
            myRigidbody.drag = 0.0f;
        }
        if (myRigidbody.velocity.x < 0.0f)
        {
            sr.flipX = true;
        }
        if (myRigidbody.velocity.x > 0.0f)
        {
            sr.flipX = false;
        }
        if(!moving_anim_playing && myRigidbody.velocity.magnitude > 0.0f && 
           !attack_anim_playing && !shielding){
            moving_anim_playing = true;
            anim.Play("Jelly walking");
        }
        if(myRigidbody.velocity.Equals(Vector2.zero) && moving_anim_playing){
            moving_anim_playing = false;
            anim.Play("Jelly idle");
        }
        if(Input.GetKeyDown(KeyCode.J) && !attack_anim_playing){
            shielding = false;
            moving_anim_playing = false;
            attack_anim_playing = true;
            anim.Play("Jelly attack");
        }
        if(attack_anim_playing && anim.GetCurrentAnimatorStateInfo(0).IsName("Jelly idle")){
            attack_anim_playing = false;
        }
        if (Input.GetKey(KeyCode.K) && !shielding && !attack_anim_playing){
            shielding = true;
            moving_anim_playing = false;
            //attack_anim_playing = false;
            anim.Play("Jelly shielding");
        }
        if(Input.GetKeyUp(KeyCode.K) && shielding){
            shielding = false;
            anim.Play("Jelly idle");
        }

    }
}
