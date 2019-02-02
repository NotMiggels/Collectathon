using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squash_script : MonoBehaviour {
    public float top_spd; //1.6
    public float jump_velo; //200
    public float accel; //8
    public float brake_drag; //10
    public GameObject sprite;
    private bool chasing_player;//flag that marks if this enemy is chasing the player

    private GameObject player;
    private Animator anim;
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myCollider;
    private SpriteRenderer sr;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myRigidbody.freezeRotation = true;
        sr = sprite.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
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
         
	}

    void ChasePlayer(GameObject p)
    {
        player = p;
        chasing_player = true;
    }
    void Idle()
    {
        chasing_player = false;
    }
}
