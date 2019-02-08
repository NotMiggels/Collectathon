using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing1 : MonoBehaviour {
  
    private master_script ms;
    private GameObject[] CTs;
    public GameObject portal;
    private bool portal_activate;
    private bool primaryCTsCollected;
    /*
     * the following static object and Awake() is used to prevent duplicate objects
     * being generated when loading a scene
     * 
     * 
     */ 
    private static testing1 t1;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (t1 == null)
        {
            t1 = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        /*
         * this is the flag that controls whether the portal should be activated
         * can be modified to be other conditions as well 
         */
        primaryCTsCollected = true; 
                                     
        portal_activate = false;
        portal.SetActive(portal_activate);
        CTs = GameObject.FindGameObjectsWithTag("LV1CT1");
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * check for conditions if portal isn't activated
         */
        if (!portal_activate)
        {
            foreach (GameObject ct in CTs)
            {
                if (!ct.GetComponent<crispy_toast>().Collected())
                {
                    primaryCTsCollected = false;
                    break;
                }
                else
                {
                    primaryCTsCollected = true;
                }
            }
        }
        /*
         * if portal isn't activated and conditions are met
         * activate the portal
         */
        if (primaryCTsCollected && !portal_activate)
        {
            portal_activate = true;
            portal.SetActive(portal_activate);
        }
	}
}
