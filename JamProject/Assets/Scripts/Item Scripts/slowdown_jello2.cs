using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowdown_jello2 : MonoBehaviour {
    public float destruct_cd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        destruct_cd -= Time.deltaTime;
        if(destruct_cd < 0)
        {
            Destroy(this.gameObject);
        }
	}
}
