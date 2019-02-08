using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class master_script : MonoBehaviour {

    private int ct_count;//ct stands for crispy toast

    private static master_script ms;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (ms == null)
        {
            ms = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        
        ct_count = 0;
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("CT count: " + ct_count);
	}
    /*
     * called by crispy toast scripts to increment the number
     */ 
    public void AddCT()
    {
        ct_count += 1;
    }
    /*
     * you know what this does
     */ 
    public int getCT()
    {
        return ct_count;
    }
}
