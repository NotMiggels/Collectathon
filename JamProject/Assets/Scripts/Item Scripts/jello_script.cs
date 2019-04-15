using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jello_script : MonoBehaviour {
    private Rigidbody2D myrb;
	// Use this for initialization
	void Start () {
        //Debug.Log("flingy");
        myrb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        

	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.otherCollider.isTrigger){
            Debug.Log("hit");
            if(myrb.IsTouchingLayers(LayerMask.GetMask("Boss", "Enemy"))){
                collision.collider.gameObject.SendMessage("TakingDMG", 5);
            }
            //collision.gameObject.SendMessage("change");
            Destroy(this.gameObject);
        }

        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
          if(collision.gameObject.tag == "cloggedhole")
        {
            collision.gameObject.SendMessage("change");
            Destroy(this.gameObject);
        }
          
    }

}
