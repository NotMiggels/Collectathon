using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class credit_scene_script : MonoBehaviour {
    public Text crouton;
    public Text CT;
    private master_script ms;
	// Use this for initialization
	void Start () {
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        CT.text = (ms.getCT() + 1).ToString();
        crouton.text = ms.getCrouton(4).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
