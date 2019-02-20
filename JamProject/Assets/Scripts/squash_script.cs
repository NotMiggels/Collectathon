using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class squash_script : MonoBehaviour
{
    public float top_spd; //1.6
    public float jump_velo; //200
    public float accel; //8
    public float brake_drag; //10
    public float attack_velo;
    public GameObject sprite;
    public GameObject attack_trigger_l;
    public GameObject attack_trigger_r;
    public float health_percentage;
    public GameObject region_trigger;
    public float bump_velo;
    public int attack_chance;
    private bool dead;
    private bool shocked;
    private bool in_air;
    private bool chasing_player;//flag that marks if this enemy is chasing the player
    private float death_countdown;
    private GameObject player;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myCollider;
    private SpriteRenderer sr;
    private Boolean attacking;
    //private Boolean in_air;
    public float health;
    private float max_health;
    // Use this for initialization
    void Start()
    {
        shocked = false;
        dead = false;
        //health = 100;
        death_countdown = 1.0f;
        in_air = false;
        max_health = health;
        anim = sprite.GetComponent<Animator>();
        //anim.trigger
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myRigidbody.freezeRotation = true;
        myRigidbody.drag = brake_drag;
        sr = sprite.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /* If chasing_player is set to true, the logic of chasing is as follows:
		 * 1. Find the player's current position
		 * 2. Find the difference between their x-coordinates
		 * 3. If minus, use the left attack trigger, else use the other one
		 * 4. The enemy is NOT allowed to move out of its patrol area, but
		 *    as the player exits the area, the chasing_player flag should be set to false
		 *    so it should be fine...???       
		 * 
		 * Attacking players:
		 * 1. There is are two separate hitboxes/triggers placed at where the actual attack takes place
		 *    (one on left and the other on right)           
		 * 2. The enemy would try to get the player inside it (which is actually chasing)
		 * 3. Once the player is inside the attack trigger, there's a chance the enemy would launch an attack
		 * 4. Attack.
		 * 
		 * Idling:
		 * 1. The enemy may stand still or patrolling within an area
		 * 2. chasing_player should be set to false       
         *
         */
        health_percentage = health / max_health;
        if (!dead)
        {
            if (myRigidbody.velocity.x > 0.0f && !shocked)
            {
                sr.flipX = true;
            }
            else if(!shocked)
            {
                sr.flipX = false;
            }
            if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && attacking && player != null)
            {
                player.SendMessage("TakeDMG", 10);
                attacking = false;
                //Debug.Log("player damaged");
            }

            in_air = !(myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) ||
                myCollider.IsTouchingLayers(LayerMask.GetMask("Platform")));
            /*
            if (!in_air && !anim.GetCurrentAnimatorStateInfo(0).IsName("Squash Shock") && chasing_player)
            {
                anim.Play("Squash Chasing");
            }
            */

            if (chasing_player && anim.GetCurrentAnimatorStateInfo(0).IsName("Squash Chasing"))
            {
                shocked = false;
                //locate the player
                Vector3 playerpos = player.transform.position;
                Vector3 mypos = this.transform.position;
                float Xdiff = playerpos.x - mypos.x;

                //right
                if (Xdiff > 0.0f)
                {
                    Vector3 triggerpos = attack_trigger_r.transform.position;
                    float Xdiff2 = playerpos.x - triggerpos.x;
                    //right
                    if (Xdiff2 > 0.2f && (myRigidbody.velocity.x) < top_spd && !in_air)
                    {
                        myRigidbody.AddForce(new Vector2(accel, accel * 1.0f));
                    }
                    //left
                    else if (Xdiff2 < -0.2f && (myRigidbody.velocity.x) > top_spd * -1.0f && !in_air)
                    {
                        myRigidbody.AddForce(new Vector2(accel * -1.0f, accel * 1.0f));
                    }
                    else if (Xdiff < 0.2f && Xdiff > -0.2f && myRigidbody.velocity.magnitude > top_spd && !in_air)
                    {
                        System.Random random = new System.Random();
                        int temp = random.Next(2);
                        if (temp == 0)
                        {
                            myRigidbody.AddForce(new Vector2(accel, accel * 1.0f));
                        }
                        else
                        {
                            myRigidbody.AddForce(new Vector2(accel * -1.0f, accel * 1.0f));
                        }
                    }
                    else if (!in_air) //attack
                    {
                        System.Random random = new System.Random();
                        int temp = random.Next(101);
                        if (temp < attack_chance)
                        {
                            myRigidbody.AddForce(new Vector2(attack_velo, attack_velo));
                            attacking = true;
                            //anim.Play("Squash Jump");
                        }
                    }
                }

                //left
                else
                {
                    Vector3 triggerpos = attack_trigger_l.transform.position;
                    float Xdiff2 = playerpos.x - triggerpos.x;
                    //right
                    if (Xdiff2 > 0.2f && (myRigidbody.velocity.x) < top_spd && !in_air)
                    {
                        myRigidbody.AddForce(new Vector2(accel, accel * 1.0f));
                    }
                    //left
                    else if (Xdiff2 < -0.2f && (myRigidbody.velocity.x) > top_spd * -1.0f && !in_air)
                    {
                        myRigidbody.AddForce(new Vector2(accel * -1.0f, accel * 1.0f));
                    }
                    else if (Xdiff < 0.2f && Xdiff > -0.2f && myRigidbody.velocity.magnitude > top_spd && !in_air)
                    {
                        System.Random random = new System.Random();
                        int temp = random.Next(2);
                        if (temp == 0)
                        {
                            myRigidbody.AddForce(new Vector2(accel, accel * 1.0f));
                        }
                        else
                        {
                            myRigidbody.AddForce(new Vector2(accel * -1.0f, accel * 1.0f));
                        }
                    }
                    else if (!in_air) //attack
                    {
                        System.Random random = new System.Random();
                        int temp = random.Next(101);
                        if (temp < attack_chance)
                        {
                            myRigidbody.AddForce(new Vector2(-1.0f * attack_velo, attack_velo));
                            attacking = true;
                            //anim.Play("Squash Jump");
                        }
                    }
                }
            }
            if (health <= 0.0f)
            {
                region_trigger.SendMessage("EnemyDecrement");
                anim.Play("Squash Death");
                dead = true;
                health_percentage = 0.0f;
                //Destroy(myRigidbody.gameObject);

            }
        }
    

            
        else
        
        {
        
            death_countdown -= Time.deltaTime;

            if (death_countdown < 0)
            
            {
            
                Destroy(myRigidbody.gameObject);

            }
          
        }

    }

    /*
     * a function used to set the flag
     * p is passed in from another script via SendMessage
     * this function should be called by SendMessage as well   
     */   
    void ChasePlayer(GameObject p)
    {
        player = p;
        if (!chasing_player)
        {
            Debug.Log("squash shocked");
            if(p.transform.position.x > this.transform.position.x){
                sr.flipX = true;
                shocked = true;
            }
            anim.Play("Squash Shock");
        }
        chasing_player = true;
    }
    /*
     * same as ChasePlayer
     */
    void Idle()
    {
        Debug.Log("squash idle");
        player = null;
        anim.Play("Squash Idle");
        chasing_player = false;

    }

    void TakingDMG(int dmg){
        health -= dmg;
    }

    void Knocked(Vector2 v){
        myRigidbody.AddForce(v);
    }

}
