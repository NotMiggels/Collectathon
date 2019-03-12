using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jello2_script2 : MonoBehaviour {

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
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 10.0f;
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
