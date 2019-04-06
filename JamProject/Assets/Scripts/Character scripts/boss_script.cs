using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_script : MonoBehaviour {
    public GameObject default_pos_L;
    public GameObject default_pos_R;
    public GameObject up_pos;
    public GameObject m_sprite;
    public GameObject r_sprite;
    public float max_health;
    public GameObject cannon_projectile;
    public GameObject lighter_projectile;
    public GameObject spatula_hitbox_L;
    public GameObject spatula_hitbox_R;
    public float move_spd;
    public float spin_atk_spd;
    public int spin_dmg;
    private CircleCollider2D myCollider;
    private Rigidbody2D myRigidbody;
    private SpriteRenderer m_sr;
    private SpriteRenderer r_sr;
    private Animator m_anim;
    private Animator r_anim;
    private float health;
    private bool attacking;
    private bool moving;
    private bool in_position;
    private bool preparing_atk;
    private bool on_left;
    private bool on_right;
    private GameObject player;
    private int attack_choice; // 0:none, 1:spin, 2:cannon, 3:spatula, 4:lighter 
    private Vector3 spin_target;

	// Use this for initialization
    void Start () {
        attack_choice = 0;
        preparing_atk = false;
        on_left = false;
        on_right = false;
        attacking = false;
        moving = false;
        in_position = false;
        health = max_health;
        myCollider = GetComponent<CircleCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        m_sr = m_sprite.GetComponent<SpriteRenderer>();
        m_anim = m_sprite.GetComponent<Animator>();
        r_sr = r_sprite.GetComponent<SpriteRenderer>();
        r_anim = r_sprite.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        myRigidbody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(myRigidbody.velocity.x > 0){
            m_sr.flipX = true;
            r_sr.flipX = true;
        }
        else if(myRigidbody.velocity.x < 0){
            m_sr.flipX = false;
            r_sr.flipX = false;
        }
        if(myCollider.IsTouchingLayers(LayerMask.GetMask("Player"))){
            if (attack_choice == 1)
            {
                player.SendMessage("TakeDMG", spin_dmg);
            }
        }
		/*
		 * if boss is not in position, not attacking, and not moving, move to either L or R position
		 */
        if(!in_position && !attacking && !moving && !preparing_atk){
            MoveToStandbyLocation();
        }
        /*
         * if boss is moving, but not in position or attacking, then it's on its way to the position.
         */ 
        else if(moving && !in_position && !attacking && !preparing_atk){
            //if it has reached the position, or even passing it
            Moving();
        }
        /*
         * if boss is not moving or attacking, but in position, then it's prepared to attack
         */
        else if(!moving && !attacking && in_position && !preparing_atk){
            AttackPrep();
        }
        /*
         * attacking
         */ 
        else if(!moving && attacking && !in_position && !preparing_atk){
            Attack();
        }
        /*
         * check if it has gone past the player (spin attack)
         */ 
        else if(moving && attacking && !in_position && !preparing_atk){
            if(attack_choice == 1){
                CheckSpin();
            }
        }
	}

    private void CheckSpin(){
        if(transform.position.x < spin_target.x + 0.15f && transform.position.x > spin_target.x - 0.15f){
            MoveToOppositeStandbyLocation();
        }
    }
    /*
     * this function is called by animation event
     */ 
    private void StartAttack(){
        in_position = false;
        preparing_atk = false;
        moving = false;
        if(attack_choice == 1){
            //play and loop the spinning animation
            Debug.Log("playing attack anim");
            r_anim.Play("Attack1");
        }
        else if(attack_choice == 2){
            
        }
        else if(attack_choice == 3){
            
        }
        else if(attack_choice == 4){
            
        }
        attacking = true;
    }
    private void MoveToStandbyLocation(){
        attack_choice = 0;
        Debug.Log("boss starts moving");
        System.Random rng = new System.Random();
        int temp = rng.Next(0, 2);
        if (temp == 0)
        {
            Debug.Log("boss moves L");
            //go left
            Vector3 dir = default_pos_L.transform.position - transform.position;
            //Debug.Log("dir (b4 normalization): " + dir);
            dir.Normalize();
            //Debug.Log("dir (normolized)" + dir);
            dir *= move_spd;
            //Debug.Log("dir (scaled): " + dir);
            myRigidbody.velocity = new Vector2(dir.x, dir.y);
            //Debug.Log("boss velocity: " + myRigidbody.velocity);

        }
        else
        {
            Debug.Log("boss moves R");
            //go right
            Vector3 dir = default_pos_R.transform.position - transform.position;
            //Debug.Log("dir (b4 normalization): " + dir);
            dir.Normalize();
            //Debug.Log("dir (normolized)" + dir);
            dir *= move_spd;
            //Debug.Log("dir (scaled): " + dir);
            myRigidbody.velocity = new Vector2(dir.x, dir.y);
            //Debug.Log("boss velocity: " + myRigidbody.velocity);
           
        }
        moving = true;
        in_position = false;
        attacking = false;
        preparing_atk = false;
    }
    private void MoveToOppositeStandbyLocation()
    {
        attack_choice = 0;
        Debug.Log("boss starts moving");
        //System.Random rng = new System.Random();
        if(on_right)
        {
            Debug.Log("boss moves L");
            //go left
            Vector3 dir = default_pos_L.transform.position - transform.position;
            //Debug.Log("dir (b4 normalization): " + dir);
            dir.Normalize();
            //Debug.Log("dir (normolized)" + dir);
            dir *= move_spd;
            //Debug.Log("dir (scaled): " + dir);
            myRigidbody.velocity = new Vector2(dir.x, dir.y);
            //Debug.Log("boss velocity: " + myRigidbody.velocity);

        }
        else
        {
            Debug.Log("boss moves R");
            //go right
            Vector3 dir = default_pos_R.transform.position - transform.position;
            //Debug.Log("dir (b4 normalization): " + dir);
            dir.Normalize();
            //Debug.Log("dir (normolized)" + dir);
            dir *= move_spd;
            //Debug.Log("dir (scaled): " + dir);
            myRigidbody.velocity = new Vector2(dir.x, dir.y);
            //Debug.Log("boss velocity: " + myRigidbody.velocity);

        }
        moving = true;
        in_position = false;
        attacking = false;
        preparing_atk = false;
    }
    private void Moving(){
        attack_choice = 0;
        if(!r_anim.GetCurrentAnimatorStateInfo(0).IsName("Boss Idle")){
            Debug.Log("playing idle anim (Moving:())");
            r_anim.Play("Boss Idle");
        }

        if (transform.position.x < default_pos_L.transform.position.x)
        {
            Debug.Log("boss stops at L");
            //stop
            myRigidbody.velocity = Vector2.zero;
            moving = false;
            in_position = true;
            on_left = true;
            on_right = false;
            in_position = true;
            r_sr.flipX = true;
            m_sr.flipX = true;
        }
        else if (transform.position.x > default_pos_R.transform.position.x)
        {
            //stop
            Debug.Log("boss stops at R");
            myRigidbody.velocity = Vector2.zero;
            moving = false;
            in_position = true;
            on_right = true;
            on_left = false;
            r_sr.flipX = false;
            m_sr.flipX = false;
        }
       

        attacking = false;
        preparing_atk = false;
    }
    private void Attack(){
        //do what needs to be done
        attacking = true;
        Debug.Log("boss attacks, attack_choice = " + attack_choice);
        if (attack_choice == 1)
        {
            Debug.Log("boss spins");
            //start moving towards player
            spin_target = player.transform.position;
            Vector3 dir = spin_target - transform.position;
            dir.Normalize();
            dir *= spin_atk_spd;
            myRigidbody.velocity = new Vector2(dir.x, dir.y);
            moving = true;
        }
        else if (attack_choice == 2)
        {

        }
        else if (attack_choice == 3)
        {

        }
        else if (attack_choice == 4)
        {
            
        }
    }
    private void AttackPrep(){
        Debug.Log("boss preparing for attack");
       
        if((player.transform.position.x < default_pos_R.transform.position.x
            && player.transform.position.x > default_pos_L.transform.position.x)){
            System.Random rng = new System.Random();
            //int temp = rng.Next(1, 3);
            //Debug.Log("boss idle for " + temp + " seconds");
            //yield return new WaitForSeconds(temp);
            //int temp = rng.Next(0, 4);
            int temp = 0;
            if (temp == 0)
            {
                //spin
                preparing_atk = true;
                Debug.Log("playing pre-attack anim (spin)");
                r_anim.Play("Pre-Attack1");
                attack_choice = temp + 1;
            }
            else if (temp == 1)
            {
                //cannon
            }
            else if (temp == 2)
            {
                //spatula
            }
            else if (temp == 3)
            {
                //candle lighter
            }
        }
        else{
            Debug.Log("player not in range, suspend");
        }

    }
}
