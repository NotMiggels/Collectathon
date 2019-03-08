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
        Destroy(this.gameObject);
    }

}
