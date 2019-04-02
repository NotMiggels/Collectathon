using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jello_script : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Debug.Log("flingy");
	}
	
	// Update is called once per frame
	void Update () {
        

	}
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
          
        //collision.gameObject.SendMessage("change");
     
        Destroy(this.gameObject);
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
          if(collision.gameObject.tag == "cloggedhole")
        {
            collision.gameObject.SendMessage("change");
        }
          Destroy(this.gameObject);
    }

}
