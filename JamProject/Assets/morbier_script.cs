using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morbier_script : MonoBehaviour {
    private Rigidbody2D myRigidbody;
    private BoxCollider2D myBoxCollider;
    private Animator anim;
    public Dialogue dialogue;
    private bool grounded;
    private bool spoken;
    public GameObject da_toastie;
	// Use this for initialization
	void Start () {
        da_toastie.SetActive(false);
        spoken = false;
        grounded = false;
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        Physics2D.IgnoreCollision(myBoxCollider, GameObject.FindGameObjectWithTag("Player").GetComponent<CapsuleCollider2D>());

	}
	
	// Update is called once per frame
	void Update () {
        if(myRigidbody.IsTouchingLayers(LayerMask.GetMask("Platform")) && !grounded){
            Debug.Log("not fucked");
            grounded = true;
            anim.Play("Boss stunned");
        }
        if (grounded && !spoken){
            spoken = true;
            GameObject.FindGameObjectWithTag("UIManager").GetComponent<UI_healthbar>().ShowDialogueBox();
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue, gameObject);
            da_toastie.SetActive(true);
        }
    }
    void Fall(){
        myRigidbody.simulated = true;
        anim.Play("Boss falls");
    }
}
