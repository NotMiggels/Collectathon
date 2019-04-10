using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class JungleScript : MonoBehaviour {
    private string own_scene;
    private master_script ms;
    private GameObject[] CTs;
    public GameObject portal;
    public string container_tag;
    private GameObject crispys;
    private bool portal_activate;
    private bool primaryCTsCollected;
    private bool scene_confirmed;
    private crispy_toast[] ct_Scripts;
    /*
     * the following static object and Awake() is used to prevent duplicate objects
     * being generated when loading a scene
     * 
     * 
     */
    private static JungleScript t1;
    
    void Awake()
    {
        DontDestroyOnLoad(this);
        own_scene = SceneManager.GetActiveScene().name;
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
    void Start()
    {
        /*
         * this is the flag that controls whether the portal should be activated
         * can be modified to be other conditions as well 
         */
        scene_confirmed = true;
        crispys = GameObject.FindGameObjectWithTag(container_tag);
        primaryCTsCollected = true;
        ct_Scripts = crispys.GetComponentsInChildren<crispy_toast>();
        Debug.Log(ct_Scripts.Length);
        foreach (crispy_toast ct in ct_Scripts)
        {
            ct.gameObject.SetActive(true);
        }
        if (portal != null)
        {
            portal_activate = false;
            portal.SetActive(portal_activate);
        }

        CTs = GameObject.FindGameObjectsWithTag("JungleToast1");
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * check for conditions if portal isn't activated
         */
        if (own_scene != SceneManager.GetActiveScene().name)
        {
            //Debug.Log("not in testing1");
            scene_confirmed = false;
        }
        if (!scene_confirmed && SceneManager.GetActiveScene().name == own_scene)
        {
            Debug.Log(ct_Scripts.Length);
            foreach (crispy_toast ct in ct_Scripts)
            {
                ct.gameObject.SetActive(true);
            }
            scene_confirmed = true;
        }
        //primaryCTsCollected = true;
        if (portal != null)
        {
            primaryCTsCollected = true;
            if (!portal_activate)
            {
                foreach (GameObject CT in CTs)
                {
                    if (!CT.GetComponent<crispy_toast>().Collected())
                    {
                        primaryCTsCollected = false;
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
        /*
        if (!portal_activate)
        {
            foreach (GameObject CT in CTs)
            {
                if (!CT.GetComponent<crispy_toast>().Collected())
                {
                    primaryCTsCollected = false;
                }
            }
        }
        /*
         * if portal isn't activated and conditions are met
         * activate the portal
         */
        /*
        if (primaryCTsCollected && !portal_activate)
        {
            portal_activate = true;
            portal.SetActive(portal_activate);
        }
        */
    }
}

