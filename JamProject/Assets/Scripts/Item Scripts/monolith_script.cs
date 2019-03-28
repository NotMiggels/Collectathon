using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monolith_script : MonoBehaviour {
    public float destruct_countdown;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        destruct_countdown -= Time.deltaTime;
        if (destruct_countdown <= 0)
        {
            Destroy(gameObject);
        }
	}
}
