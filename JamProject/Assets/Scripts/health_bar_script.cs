using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_bar_script : MonoBehaviour {
    Vector3 ls;
    public GameObject parent;
    private squash_script script;
    private float orig_scale;
	// Use this for initialization
	void Start () {
        script = parent.GetComponent<squash_script>();
        ls = transform.localScale;
        orig_scale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (script.health_percentage > 0.0f)
        {
            ls.x = orig_scale * script.health_percentage;
        }
        transform.localScale = ls;
	}
}
