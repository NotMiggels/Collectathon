using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerControl : MonoBehaviour {


    public float top_spd; //1
    public float jump_velo; //20
    public float accel; //.45
    public float brake_drag; //10
    public GameObject atk_trigger_l;
    public GameObject atk_trigger_r;
    public GameObject sprite;
    public float health;
    public float health_percentage;
    private float max_health;

    //public GameObject hitbox;
    private bool playerMoving;
    private Vector2 lastMove;

    private Animator anim;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myCollider;
    private BoxCollider2D trig_l;
    private BoxCollider2D trig_r;
    private bool in_air;
    private bool W_pressed;
    private float orig_drag;
    private bool moving_anim_playing;
    private bool attack_anim_playing;
    private bool shielding;
    private bool attacking;
    private ContactFilter2D cf = new ContactFilter2D();
    private SpriteRenderer sr;
   

    // Use this for initialization
    void Start () {
        max_health = health;
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
        trig_l = atk_trigger_l.GetComponent<BoxCollider2D>();
        trig_r = atk_trigger_r.GetComponent<BoxCollider2D>();
        cf.SetLayerMask(LayerMask.GetMask("Enemy"));
        attacking = false;

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
        if (health > 0.0f)
        {
            health_percentage = health / max_health;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jelly attack"))
            {
                attack_anim_playing = true;
            }
            else
            {
                attack_anim_playing = false;
            }

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jelly walking"))
            {
                moving_anim_playing = true;
            }
            else
            {
                moving_anim_playing = false;
            }

            if (attack_anim_playing && !attacking)
            {
                Debug.Log("attack");
                attacking = true;
                //facing left
                if (sr.flipX)
                {
                    BoxCollider2D[] boxColliders = new BoxCollider2D[10];
                    int temp = trig_l.OverlapCollider(cf, boxColliders);
                    for (int a = 0; a < temp; a++)
                    {
                        boxColliders[a].gameObject.SendMessage("Knocked", new Vector2(-100.0f, 100.0f));
                        boxColliders[a].gameObject.SendMessage("TakingDMG", 25);
                    }
                }
                //facing right
                else
                {
                    BoxCollider2D[] boxColliders = new BoxCollider2D[10];
                    int temp = trig_r.OverlapCollider(cf, boxColliders);
                    for (int a = 0; a < temp; a++)
                    {
                        boxColliders[a].gameObject.SendMessage("Knocked", new Vector2(100.0f, 100.0f));
                        boxColliders[a].gameObject.SendMessage("TakingDMG", 25);
                    }
                }
            }
            if (in_air && (myCollider.IsTouchingLayers(LayerMask.GetMask("Obstacles")) ||
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
            if (Input.GetKey(KeyCode.A) && (myRigidbody.velocity.x) > top_spd * -1.0f && !shielding)
            {
                myRigidbody.AddForce(new Vector2(accel * -1.0f, 0.0f));
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                sr.flipX = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                sr.flipX = false;
            }
            if (!moving_anim_playing && myRigidbody.velocity.magnitude > 0.0f &&
               !attack_anim_playing && !shielding)
            {
                //moving_anim_playing = true;
                anim.Play("Jelly walking");
            }
            if (myRigidbody.velocity.Equals(Vector2.zero) && moving_anim_playing)
            {
                //moving_anim_playing = false;
                anim.Play("Jelly idle");
            }
            if (Input.GetKeyDown(KeyCode.J) && !attack_anim_playing)
            {
                attacking = false;
                shielding = false;
                //moving_anim_playing = false;
                //attack_anim_playing = true;
                anim.Play("Jelly attack");
            }
            if (attack_anim_playing && anim.GetCurrentAnimatorStateInfo(0).IsName("Jelly idle"))
            {
                attacking = false;
                //attack_anim_playing = false;
            }
            if (Input.GetKey(KeyCode.K) && !shielding && !attack_anim_playing)
            {
                shielding = true;
                //moving_anim_playing = false;
                //attack_anim_playing = false;
                anim.Play("Jelly shielding");
            }
            if (Input.GetKeyUp(KeyCode.K) && shielding)
            {
                shielding = false;
                anim.Play("Jelly idle");
            }
        }
        else{
            GameObject.FindGameObjectWithTag("MainCamera").SendMessage("EndGame");
        }
    }
    void TakeDMG(int dmg){
        if (!shielding)
        {
            health -= dmg;
        }
    }
    void Knocked(Vector2 v)
    {
        myRigidbody.AddForce(v);
    }
}
