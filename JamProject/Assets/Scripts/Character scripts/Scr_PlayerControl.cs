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
    private GameObject UI_manager;
    public float gauge_time; //how long would the gauge last
                             //from a full charge (w/o) using active ability
    public float dmg_cd;
    public float health;
    public float health_percentage;
    public float jump_boost;
    public float swamp_drag;
    public float fling_spd;
    public float jello_spd;//jello in ability #1
    public float fling_spd_up;
    public float jello_spd_up;//jello in ability #1
    public float gauge_recover_time; //the time it takes for the gauge to fully recover
    public Rigidbody2D jello;
    public Rigidbody2D jello2;
    public AudioClip swing;
    private AudioSource audio;
    private float max_health;
    private float dmg_cd_default;
    private float ability_gauge;
    private bool dmg_cooling;
    //public GameObject hitbox;
    private bool playerMoving;
    private bool ability_active;
    private int selected_ability; // a flag that represents the selected ability
                                  // 0 = none
    public int ability_count; //the number of abilities Jelly has,
                              //excluding the default state (as ability #0)
    private Vector2 lastMove;
    private master_script ms;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    private CapsuleCollider2D myCollider;
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
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        ability_active = false;
        ability_gauge = 1.0f;
        dmg_cooling = false;
        dmg_cd_default = dmg_cd;
        audio = GetComponent<AudioSource>();
        health = ms.getJellyHealth();
        max_health = health;
        in_air = true;
        W_pressed = false;
        anim = sprite.GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
        myRigidbody.freezeRotation = true;
        sr = sprite.GetComponent<SpriteRenderer>();
        moving_anim_playing = false;
        attack_anim_playing = false;
        shielding = false;
        trig_l = atk_trigger_l.GetComponent<BoxCollider2D>();
        trig_r = atk_trigger_r.GetComponent<BoxCollider2D>();
        cf.SetLayerMask(LayerMask.GetMask("Enemy"));
        attacking = false;
        selected_ability = 0;
        UI_manager = GameObject.FindGameObjectWithTag("UIManager");
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
        /*
         * A block of code that prevents Jelly
         * from taking too much damage from an attack
         */
        if (dmg_cooling)
        {
            dmg_cd -= Time.deltaTime;
            if(dmg_cd < 0)
            {
                dmg_cd = dmg_cd_default;
                dmg_cooling = false;
            }
        }
        /*
         * If Jelly is not dead
         */
        if (health > 0.0f)
        {
            /*
             * Check animation status
             */ 
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
            /*
             * attack
             */
            if (attack_anim_playing && !attacking)
            {
                Debug.Log("attack");
                attacking = true;
                audio.clip = swing;
                audio.Play();
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
            /*
             * Block of code that resets Jelly's vertical velocity as he touches the ground
             */
            if (in_air && (myCollider.IsTouchingLayers(LayerMask.GetMask("Obstacles")) ||
                myCollider.IsTouchingLayers(LayerMask.GetMask("Platform"))))
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0.0f);
            }
            /*
             * Block of code that checks if Jelly is in mid air
             */ 
            in_air = !(myCollider.IsTouchingLayers(LayerMask.GetMask("Obstacles")) ||
                myCollider.IsTouchingLayers(LayerMask.GetMask("Platform")));
            //Jelly would be able to keep jumping in swamp
            if (myCollider.IsTouchingLayers(LayerMask.GetMask("Swamp")))
            {
                in_air = false;
                myRigidbody.drag = swamp_drag;
            }
            else
            {
                myRigidbody.drag = 0;
            }

            //Debug.Log(in_air);
            /*
             * Jump
             */
            if (Input.GetKey(KeyCode.W) && !in_air && !W_pressed && !shielding)
            {
                W_pressed = true;
                myRigidbody.AddForce(new Vector2(0.0f, jump_velo * (1.0f + jump_boost)));
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                W_pressed = false;
            }
            /*
             * Go left
             */
            if (Input.GetKey(KeyCode.A) && (myRigidbody.velocity.x) > top_spd * -1.0f && !shielding)
            {
                myRigidbody.AddForce(new Vector2(accel * -1.0f, 0.0f));
            }
            /*
             * Go right
             */ 
            if (Input.GetKey(KeyCode.D) && (myRigidbody.velocity.x) < top_spd && !shielding)
            {
                myRigidbody.AddForce(new Vector2(accel, 0.0f));
            }
            /*
             * Brake
             */ 
            if (Input.GetKey(KeyCode.S) && !in_air && myRigidbody.velocity.magnitude > 0.0f && !shielding)
            {
                //orig_drag = myRigidbody.drag;
                myRigidbody.drag = brake_drag;
            }
            /*
             * End braking
             */
            if (Input.GetKeyUp(KeyCode.S) && !in_air)
            {
                myRigidbody.drag = 0.0f;
            }
            /*
             * Code that flips the sprite as Jelly moves towards left or right
             */ 
            if (Input.GetKey(KeyCode.A))
            {
                sr.flipX = true;
            }
            if (Input.GetKey(KeyCode.D))
            {
                sr.flipX = false;
            }
            /*
             * Jelly fling
             */ 
            if (Input.GetKeyDown(KeyCode.L)){
                if (sr.flipX == true)
                {
                    Vector3 temp = new Vector3(transform.position.x - 0.35f,
                                              transform.position.y,
                                               transform.position.z);
                    Rigidbody2D jelloclone = (Rigidbody2D)Instantiate(jello, temp, transform.rotation);
                    jelloclone.velocity = (new Vector2(-1.0f * fling_spd, fling_spd_up));
                }
                else{
                    Vector3 temp = new Vector3(transform.position.x + 0.35f,
                                             transform.position.y,
                                              transform.position.z);
                    Rigidbody2D jelloclone = (Rigidbody2D)Instantiate(jello, temp, transform.rotation);
                    jelloclone.velocity = (new Vector2(1.0f * fling_spd, fling_spd_up));
                }

            }
            /*
             * Switching between states (abilities)
             */
            if (Input.GetKeyDown(KeyCode.Q) && !ability_active)
            {
                
                selected_ability -= 1;
                if(selected_ability < 0)
                {
                    selected_ability = ability_count;
                }
                UI_manager.SendMessage("SetAbilityText", selected_ability);
                Debug.Log("current ability#:" + selected_ability);
            }
            if (Input.GetKeyDown(KeyCode.E) && !ability_active)
            {
                
                selected_ability += 1;
                if(selected_ability > ability_count)
                {
                    selected_ability = 0;
                }
                UI_manager.SendMessage("SetAbilityText", selected_ability);
                Debug.Log("current ability#:" + selected_ability);
            }
            if (Input.GetKeyDown(KeyCode.U) && selected_ability != 0 && !ability_active)
            {
                Debug.Log("ability active");
                ability_active = true;
            }
            //restore passive effectors
            else if (Input.GetKeyDown(KeyCode.U) && selected_ability != 0 && ability_active)
            {
                Debug.Log("ability inactive");
                if (selected_ability == 1)
                {
                    jump_boost = 0;
                }
                ability_active = false;
            }
            //passive abilities
            if (ability_active)
            {
                ability_gauge -= Time.deltaTime * (1.0f / gauge_time);
                if(selected_ability == 1)
                {
                    jump_boost = 0.15f;
                }
            }
            //gauge refilling by time
            else if (!ability_active)
            {
                ability_gauge += Time.deltaTime * (1.0f / gauge_recover_time);
            }
            //disable ability if gauge depleted
            if(ability_gauge < 0.0f)
            {
                ability_active = false;
            }
            //active ability
            if (Input.GetKeyDown(KeyCode.I) && ability_active)
            {
                ability_gauge -= 0.3f;
                if(selected_ability == 1)
                {
                    if (sr.flipX == true)
                    {
                        Vector3 temp = new Vector3(transform.position.x - 0.35f,
                                                  transform.position.y,
                                                   transform.position.z);
                        Rigidbody2D jelloclone = (Rigidbody2D)Instantiate(jello2, temp, transform.rotation);
                        jelloclone.velocity = (new Vector2(-1.0f * jello_spd, jello_spd_up));
                    }
                    else
                    {
                        Vector3 temp = new Vector3(transform.position.x + 0.35f,
                                                 transform.position.y,
                                                  transform.position.z);
                        Rigidbody2D jelloclone = (Rigidbody2D)Instantiate(jello2, temp, transform.rotation);
                        jelloclone.velocity = (new Vector2(1.0f * jello_spd, jello_spd_up));
                    }
                }
            }
            /*
             * animation stuff
             */
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
        if (!shielding && !dmg_cooling)
        {
            health -= dmg;
            dmg_cooling = true;
        }
    }
    void Knocked(Vector2 v)
    {
        myRigidbody.AddForce(v);
    }
    public int Selected_ability()
    {
        return selected_ability;
    }
    public bool Ability_active()
    {
        return ability_active;
    }
    public float Ability_gauge()
    {
        return ability_gauge;
    }
}
