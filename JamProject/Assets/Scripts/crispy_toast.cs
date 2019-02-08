using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crispy_toast : MonoBehaviour {

    private master_script ms;
    private BoxCollider2D bc;
    private bool collected;
    private static crispy_toast ct;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (ct == null)
        {
            ct = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        DontDestroyOnLoad(this.gameObject);
        bc = GetComponent<BoxCollider2D>();
        collected = false;
    }
	
	// Update is called once per frame
	void Update () {
        /*
         * if player touches it
         */
        if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            ms.AddCT();
            collected = true;
            this.gameObject.SetActive(false);
        }
	}
    /*
     * tells whatever calls this fuction if this crispy toast has been collected
     */ 
    public bool Collected()
    {
        return collected;
    }
}
