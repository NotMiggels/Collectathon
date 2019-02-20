using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_script : MonoBehaviour {

    private BoxCollider2D bc;
	// Use this for initialization
	void Start () {
        bc = GetComponent<BoxCollider2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
