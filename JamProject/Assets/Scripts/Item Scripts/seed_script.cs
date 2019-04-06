using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class seed_script : MonoBehaviour {
    private GameObject player;
    private BoxCollider2D myCollider;
    private Rigidbody2D myRB;
    public float dmg;
    public float destruct_countdown;
    public float destruct_speed;
    private float speed_check_countdown;

	// Use this for initialization
	void Start () {
        speed_check_countdown = 1.0f;
        myCollider = GetComponent<BoxCollider2D>();
        myRB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void Update() {
        //Debug.Log("seed speed: " + myRB.velocity.magnitude);
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && player != null)
        {
            //Debug.Log("player damaged");
            player.SendMessage("TakeDMG", dmg);
            Destroy(gameObject);
        }
        else if (myCollider.IsTouchingLayers(LayerMask.GetMask("Platform", "Obstacles")))
        {
            Destroy(gameObject);
        }
        else if (myRB.velocity.magnitude < destruct_speed && speed_check_countdown <= 0.0f)
        {
            Destroy(gameObject);
        }
        if(speed_check_countdown > 0.0f)
        {
            speed_check_countdown -= Time.deltaTime;
        }
        destruct_countdown -= Time.deltaTime;
        if(destruct_countdown <= 0){
            Destroy(gameObject);
        }
	}
}
