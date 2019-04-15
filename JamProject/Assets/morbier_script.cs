using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morbier_script : MonoBehaviour {
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;
    private Animator anim;
    private bool grounded;
	// Use this for initialization
	void Start () {
        grounded = false;
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(myRigidbody.IsTouchingLayers(LayerMask.GetMask("Platform")) && !grounded){
            Debug.Log("not fucked");
            grounded = true;
            anim.Play("Boss stunned");
        }
    }
    void Fall(){
        myRigidbody.simulated = true;
        anim.Play("Boss falls");
    }
}
