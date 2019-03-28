using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health_bar_script : MonoBehaviour {
    Vector3 ls;
    public GameObject parent;
    private squash_script script;
    private Scr_PlayerControl script2;
    private banana_script script3;
    private pepper_script script4;
    private tomato_script script5;
    private float orig_scale;
    private int flag;
	// Use this for initialization
	void Start () {
        flag = 0;
        if (flag == 0)
        {
            script = parent.GetComponent<squash_script>();
            if (script != null)
            {
                flag = 1;
            }
        }
        if (flag == 0)
        {
            script2 = parent.GetComponent<Scr_PlayerControl>();
            if (script2 != null)
            {
                flag = 2;
            }
        }
        if(flag == 0){
            script3 = parent.GetComponent<banana_script>();
            if (script3 != null)
            {
                flag = 3;
            }
        }
        if(flag == 0){
            script4 = parent.GetComponent<pepper_script>();
            if(script4 != null){
                flag = 4;
            }
        }
        if (flag == 0)
        {
            script5 = parent.GetComponent<tomato_script>();
            if (script5 != null)
            {
                flag = 5;
            }
        }
        ls = transform.localScale;
        orig_scale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if(flag == 1){
            //if (script.health_percentage > 0.0f)
            //{
                //Debug.Log("squash hp -");
            if(script.health_percentage < 0.0f){
                ls.x = 0.0f;
            }
            else{
                ls.x = orig_scale * script.health_percentage;
            }
                
            //}
            transform.localScale = ls;
        }
        else if(flag == 2){
            
            if (script2.health_percentage < 0.0f)
            {
                ls.x = 0.0f;
            }
            else
            {
                ls.x = orig_scale * script2.health_percentage;
            }
            transform.localScale = ls;
        }
        else if (flag == 3)
        {

            if (script3.health_percentage < 0.0f)
            {
                ls.x = 0.0f;
            }
            else
            {
                ls.x = orig_scale * script3.health_percentage;
            }
            transform.localScale = ls;
        }
        else if (flag == 4)
        {
            
            if (script4.health_percentage < 0.0f)
            {
                ls.x = 0.0f;
            }
            else
            {
                ls.x = orig_scale * script4.health_percentage;
            }
            transform.localScale = ls;
        }
        else if (flag == 5)
        {
            
            if (script5.health_percentage < 0.0f)
            {
                ls.x = 0.0f;
            }
            else
            {
                ls.x = orig_scale * script5.health_percentage;
            }
            transform.localScale = ls;
        }
	}
}
