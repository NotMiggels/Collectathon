using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jello2_script2 : MonoBehaviour {
    public float jammed_gravity_scale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy_group1"){
            Debug.Log("enemy on jello");
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = jammed_gravity_scale;
        }
    
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy_group1")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
    }
}
