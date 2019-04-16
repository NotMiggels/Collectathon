using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class morbier_toast_script : MonoBehaviour {
    private BoxCollider2D mc;
	// Use this for initialization
	void Start () {
        mc = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(mc.IsTouchingLayers(LayerMask.GetMask("Player"))){
            SceneManager.LoadScene("CutScene3");
        }
	}
}
