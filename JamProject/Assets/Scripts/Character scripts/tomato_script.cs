using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class tomato_script : MonoBehaviour
{

    public float velo_y;
    public float velo_x;
    public GameObject sprite;
    public GameObject detection_l;
    public GameObject detection_r;
    public GameObject boundary_L;
    public GameObject boundary_R;
    public float health_percentage;
    public int attack_chance;
    public int jump_chance;
    public float max_health;
    public float jump_interval;
    public float attack_cooldown;
    public GameObject seed_L;
    public GameObject seed_R;
    public GameObject seed_L_spawn_pos;
    public GameObject seed_R_spawn_pos;
    public float seed_velo_x;
    public float seed_velo_y;
    private int attack_direction;//0 - left, 1 - right
    private float jump_countdown;
    //pepper would randomly decide whether it's going to jump once
    //per [jump_interval] seconds
    private float attack_countdown;
    private float health;
    private bool dead;
    private bool shocked;
    private bool in_air;
    private float death_countdown;
    private GameObject player;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myCollider;
    private SpriteRenderer sr;
    private bool attacking;
    private Vector2 left;
    private Vector2 right;
    private BoxCollider2D detect_l;
    private BoxCollider2D detect_r;
    //private Vector2 seed_velo_L;
    //private Vector2 seed_velo_R;

    // Use this for initialization
    void Start()
    {
        attack_countdown = -1.0f;
        shocked = false;
        dead = false;
        death_countdown = 1.0f;
        jump_countdown = jump_interval;
        in_air = false;
        health = max_health;
        anim = sprite.GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myRigidbody.freezeRotation = true;
        sr = sprite.GetComponent<SpriteRenderer>();
        left = new Vector2(-1.0f * velo_x, velo_y);
        right = new Vector2(velo_x, velo_y);
        //seed_velo_L = new Vector2(-1.0f * seed_velo_x, seed_velo_y);
        //seed_velo_R = new Vector2(seed_velo_x, seed_velo_y);
        detect_l = detection_l.GetComponent<BoxCollider2D>();
        detect_r = detection_r.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0.0f)
        {
            dead = true;
        }
        if (jump_countdown > 0.0f)
        {
            jump_countdown -= Time.deltaTime;
        }
        if (attack_countdown > 0.0f && !attacking)
        {
            attack_countdown -= Time.deltaTime;
        }
        health_percentage = health / max_health;
        if (!dead)
        {
            if (!attacking && anim.GetCurrentAnimatorStateInfo(0).IsName("Tomato_idle"))
            {
                anim.Play("Tomato_idle");
            }
            in_air = !(myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) ||
                myCollider.IsTouchingLayers(LayerMask.GetMask("Platform")) ||
                       myCollider.IsTouchingLayers(LayerMask.GetMask("Obstacles")));
            if (jump_countdown <= 0.0f && !in_air && !attacking)
            {
                Debug.Log("tomato ready to jump");
                //reset the countdown
                jump_countdown = jump_interval;
                System.Random random = new System.Random();
                int temp = random.Next(101);
                //decides whether this pepper would jump
                if (temp < jump_chance)
                {
                    //hops around
                    //if pepper is out of left bounds
                    if (transform.position.x <= boundary_L.transform.position.x)
                    {
                        //jump right

                        Jump(right);
                    }
                    //if pepper is out of right bounds
                    else if (transform.position.x >= boundary_R.transform.position.x)
                    {
                        //jump left

                        Jump(left);
                    }
                    //or picks a random direction
                    else
                    {

                        int temp2 = random.Next(101);
                        if (temp2 < 50)
                        {
                            Jump(left);
                        }
                        else
                        {
                            Jump(right);
                        }
                    }
                }
            }
            if (detect_l.IsTouchingLayers(LayerMask.GetMask("Player")) &&
                anim.GetCurrentAnimatorStateInfo(0).IsName("Tomato_idle") && attack_countdown <= 0)
            {
                //attack towards left
                System.Random random = new System.Random();
                int temp = random.Next(101);
                if (temp < attack_chance)
                {
                    sr.flipX = false;
                    attack_direction = 0;
                    attacking = true;
                    attack_countdown = attack_cooldown;
                    anim.Play("Tomato_concerned");

                    Debug.Log("Tomato attacks");
                    //Attack(true);
                }
            }
            else if (detect_r.IsTouchingLayers(LayerMask.GetMask("Player")) &&
                     anim.GetCurrentAnimatorStateInfo(0).IsName("Tomato_idle") && attack_countdown <= 0)
            {
                //attack towards right
                System.Random random = new System.Random();
                int temp = random.Next(101);
                if (temp < attack_chance)
                {
                    sr.flipX = true;
                    attack_direction = 1;
                    attacking = true;
                    attack_countdown = attack_cooldown;
                    anim.Play("Tomato_concerned");

                    Debug.Log("Tomato attacks");
                    //Attack(false);
                }
            }
        }
        else
        {
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Tomato_death"))
            {
                anim.Play("Tomato_death");
            }
        }
    }
    void TakingDMG(int dmg)
    {
        health -= dmg;
    }

    void Knocked(Vector2 v)
    {
        myRigidbody.AddForce(v);
    }
    void Jump(Vector2 v)
    {
        if (v.x > 0.0f)
        {
            Debug.Log("Tomato jump right");
            sr.flipX = true;
        }
        else
        {
            Debug.Log("Tomato jump left");
            sr.flipX = false;
        }
        myRigidbody.AddForce(v);
    }
    void Attack()
    {

        if (attack_direction == 0)
        {
            //left
            System.Random random = new System.Random();
            int temp = random.Next(3);
            temp += 3;
            for (int a = 0; a < temp; a++){
                Debug.Log("tomato attack L");
                //random modifier of seed velo on y axis
                double temp2 = random.NextDouble();
                float temp_y = (float)(seed_velo_y * temp2);
                int temp3 = random.Next(101);
                if(temp3 > 50){
                    temp_y *= -1.0f;
                }
                Vector2 vec = new Vector2(seed_velo_x * -1.0f, temp_y);
                Rigidbody2D rb2d = Instantiate(seed_L, seed_L_spawn_pos.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
                rb2d.AddForce(vec);
            }


        }
        else
        {
            //right 
            System.Random random = new System.Random();
            int temp = random.Next(3);
            temp += 3;
            for (int a = 0; a < temp; a++)
            {
                Debug.Log("tomato attack R");
                double temp2 = random.NextDouble();
                float temp_y = (float)(seed_velo_y * temp2);
                int temp3 = random.Next(101);
                if (temp3 > 50)
                {
                    temp_y *= -1.0f;
                }
                Vector2 vec = new Vector2(seed_velo_x, temp_y);
                Rigidbody2D rb2d = Instantiate(seed_R, seed_R_spawn_pos.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
                rb2d.AddForce(vec);
            }

        }
    }
    public void EndAttack()
    {
        attacking = false;
    }
}
