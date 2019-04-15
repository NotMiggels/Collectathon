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
    public GameObject monolith;
    private GameObject UI_manager;
    public float gauge_time; //how long would the gauge last
                             //from a full charge (w/o) using active ability
    public float dmg_cd;
    public float health;
    public float health_percentage;
    public float jump_boost_max;
    public float swamp_drag;
    public float fling_spd;
    public float jello_spd;//jello in ability #1
    public float fling_spd_up;
    public float jello_spd_up;//jello in ability #1
    public float gauge_recover_time; //the time it takes for the gauge to fully recover
    public float block_cooldown_max;
    private float block_cooldown;
    private bool block_cd;
    public Rigidbody2D jelloR;
    public Rigidbody2D jelloL;
    public Rigidbody2D jello2;
    public AudioClip jump;
    public AudioClip ouch;
    public AudioClip swing;
    public AudioClip fling;
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
    private bool control_disabled;
    private float jump_boost;
    public float dmg_multiplier;
    private float dmg_mult;
    private bool celebrating;
    private bool dead;
    // Use this for initialization
    void Start () {
        dead = false;
        block_cd = false;
        block_cooldown = -1.0f;
        control_disabled = false;
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        ability_active = false;
        ability_gauge = ms.getJellyGauge(); //inherited from master script
        health = ms.getJellyHealth(); //inherited from master script
        dmg_cooling = false;
        dmg_cd_default = dmg_cd;
        audio = GetComponent<AudioSource>();
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
        cf.SetLayerMask(LayerMask.GetMask("Enemy", "Boss"));
        attacking = false;
        selected_ability = 0;
        UI_manager = GameObject.FindGameObjectWithTag("UIManager");
        dmg_mult = 1.0f;
        if (ms.get_definedSpawn())
        {
            myRigidbody.transform.position = ms.getSpawnLocation();
        }
        jump_boost = 0.0f;
        celebrating = false;
    }

	// Update is called once per frame
	void Update () {
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
        if(block_cd){
            block_cooldown -= Time.deltaTime;
        }
        /*
         * If Jelly is not dead
         */
        if (health > 0.0f)
        {
            if(!shielding && (health < max_health)){
                Debug.Log("jelly healing: " + Time.deltaTime * 0.5f);
                health += Time.deltaTime * 0.5f;
            }
            /*
             * Check animation status
             */
            if (!celebrating){
                health_percentage = health / max_health;
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jelly attack") ||
                anim.GetCurrentAnimatorStateInfo(0).IsName("Jelly attack2"))
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
                    Collider2D[] boxColliders = new Collider2D[10];
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
                    Collider2D[] boxColliders = new Collider2D[10];
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

            if (!control_disabled)
            {
                /*
                * Jump
                */
                if (Input.GetKey(KeyCode.Space) && !in_air && !W_pressed && !shielding)
                {
                    W_pressed = true;
                    myRigidbody.AddForce(new Vector2(0.0f, jump_velo * (1.0f + jump_boost)));
                    audio.clip = jump;
                    audio.Play();
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
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                W_pressed = false;
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
            if (Input.GetKeyDown(KeyCode.J) && !shielding && health > 99.0f)
            {
                JellyFling();
            }
            /*
             * Switching between states (abilities)
             */
            if (Input.GetKeyDown(KeyCode.Q) && !ability_active)
            {
                AbilitySelectL();
            }
            if (Input.GetKeyDown(KeyCode.E) && !ability_active)
            {
                AbilitySelectR();
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
                RestorePassive();
            }
            //passive abilities
            if (ability_active)
            {
                ActivatePassive();
            }
            //gauge refilling by time
            else if (ability_gauge < 1.0f)
            {
                ability_gauge += Time.deltaTime * (1.0f / gauge_recover_time);
            }
            //disable ability if gauge depleted
            if (ability_gauge < 0.0f)
            {
                ability_active = false;
                RestorePassive();
            }
            //active ability
            if (Input.GetKeyDown(KeyCode.I) && ability_active)
            {
                ability_gauge -= 0.3f;
                ActivateActive();
            }
            /*
             * animation stuff
             */
            if (!moving_anim_playing && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) &&
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
            if (Input.GetKeyDown(KeyCode.J) && !attack_anim_playing && !shielding)
            {
                attacking = false;
                if (shielding)
                {
                    anim.Play("Jelly attack2");
                    shielding = false;
                }
                else
                {
                    anim.Play("Jelly attack");
                }
                shielding = false;
                //moving_anim_playing = false;
                //attack_anim_playing = true;

            }
            if (attack_anim_playing && anim.GetCurrentAnimatorStateInfo(0).IsName("Jelly idle"))
            {
                attacking = false;
                //attack_anim_playing = false;
            }
            if (Input.GetKey(KeyCode.K) && !shielding && !attack_anim_playing && block_cooldown < 0)
            {
                block_cooldown = block_cooldown_max;
                shielding = true;
                //moving_anim_playing = false;
                //attack_anim_playing = false;
                anim.Play("Jelly shielding");
            }
            if (Input.GetKeyUp(KeyCode.K) && shielding)
            {
                shielding = false;
                block_cd = true;
                anim.Play("Jelly idle");
            }
        }
        }
        else if(!dead){
            dead = true;
            anim.Play("Jelly death");
            StartCoroutine(EndGame());
        }
    }
    public void TakeDMG(int dmg){
        if (!shielding && !dmg_cooling)
        {
            health -= (float)dmg * dmg_mult;
            dmg_cooling = true;
            audio.clip = ouch;
            audio.Play();
        }
    }
    private IEnumerator EndGame(){
        yield return new WaitForSeconds(2);
        GameObject.FindGameObjectWithTag("MainCamera").SendMessage("EndGame");
    }
    void Knocked(Vector2 v)
    {
        myRigidbody.AddForce(v);
    }
    void RestorePassive(){
        if (selected_ability == 1)
        {
            UI_manager.SendMessage("HidePassive1");
            jump_boost = 0;
        }
        else if(selected_ability == 2){
            UI_manager.SendMessage("HidePassive2");
            dmg_mult = 1.0f;
        }
        ability_active = false;
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
    public void DiasbleControl()
    {
        control_disabled = true;
    }
    public void EnableControl()
    {
        control_disabled = false;
    }
    private void JellyFling(){
        if(true){
            if (sr.flipX == true)
            {
                Vector3 temp = new Vector3(transform.position.x - 0.35f,
                                          transform.position.y,
                                           transform.position.z);
                Rigidbody2D jelloclone = (Rigidbody2D)Instantiate(jelloL, temp, transform.rotation);
                jelloclone.velocity = (new Vector2(-1.0f * fling_spd, fling_spd_up));
            }
            else
            {
                Vector3 temp = new Vector3(transform.position.x + 0.35f,
                                         transform.position.y,
                                          transform.position.z);
                Rigidbody2D jelloclone = (Rigidbody2D)Instantiate(jelloR, temp, transform.rotation);
                jelloclone.velocity = (new Vector2(1.0f * fling_spd, fling_spd_up));
            }
            audio.clip = fling;
            audio.Play();
        }

    }
    private void AbilitySelectL(){
        selected_ability -= 1;
        if (selected_ability < 0)
        {
            selected_ability = ability_count;
        }
        UI_manager.SendMessage("SetAbilityText", selected_ability);
        UI_manager.SendMessage("SetAbilityBar", selected_ability);

        Debug.Log("current ability#:" + selected_ability);
    }
    private void AbilitySelectR(){
        selected_ability += 1;
        if (selected_ability > ability_count)
        {
            selected_ability = 0;
        }
        UI_manager.SendMessage("SetAbilityText", selected_ability);
        UI_manager.SendMessage("SetAbilityBar", selected_ability);

        Debug.Log("current ability#:" + selected_ability);
    }
    private void ActivatePassive(){
        ability_gauge -= Time.deltaTime * (1.0f / gauge_time);
        Debug.Log(ability_gauge);
        if (selected_ability == 1)
        {
            UI_manager.SendMessage("ShowPassive1");
            jump_boost = jump_boost_max;
        }
        if (selected_ability == 2){
            UI_manager.SendMessage("ShowPassive2");
            dmg_mult = dmg_multiplier;
        }
    }
    private void ActivateActive(){
        ability_gauge -= 0.3f;
        if (selected_ability == 1)
        {
            if (sr.flipX == true)//left
            {
                Vector3 temp = new Vector3(transform.position.x - 0.35f,
                                          transform.position.y,
                                           transform.position.z);
                Rigidbody2D jelloclone = (Rigidbody2D)Instantiate(jello2, temp, transform.rotation);
                jelloclone.velocity = (new Vector2(-1.0f * jello_spd, jello_spd_up));
            }
            else//right
            {
                Vector3 temp = new Vector3(transform.position.x + 0.35f,
                                         transform.position.y,
                                          transform.position.z);
                Rigidbody2D jelloclone = (Rigidbody2D)Instantiate(jello2, temp, transform.rotation);
                jelloclone.velocity = (new Vector2(1.0f * jello_spd, jello_spd_up));
            }
        }
        else if (selected_ability == 2)
        {
            if (sr.flipX == true)
            {//left
                Vector3 temp = new Vector3(transform.position.x - 0.5f,
                                           transform.position.y + 0.5f,
                                           transform.position.z);
                Instantiate(monolith, temp, transform.rotation);
            }
            else
            {//right
                Vector3 temp = new Vector3(transform.position.x + 0.5f,
                                           transform.position.y + 0.5f,
                                           transform.position.z);
                Instantiate(monolith, temp, transform.rotation);
            }
        }
    }
    public void CelebrateOnToast(){
        celebrating = true;
        Debug.Log("enter celebration");
        control_disabled = true;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        anim.Play("Jelly celebrating");
    }
    public void EndCelebration(){
        celebrating = false;
        Debug.Log("exit celebration");
        control_disabled = false;
        myRigidbody.constraints = RigidbodyConstraints2D.None;
        myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
