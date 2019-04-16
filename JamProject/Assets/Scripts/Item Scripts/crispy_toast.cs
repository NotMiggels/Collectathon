using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crispy_toast : MonoBehaviour {

    private master_script ms;
    private BoxCollider2D bc;
    private bool collected;
    private int self_count;
    private string own_scene;
    public bool ready;
    public bool show_on_defeating_enemy;
    //public GameObject[] enemies;
    //private GameObject ct;
    void Awake()
    {
        DontDestroyOnLoad(this);
        own_scene = SceneManager.GetActiveScene().name;
        self_count = 0;
        crispy_toast[] CTs = Resources.FindObjectsOfTypeAll<crispy_toast>();
        foreach(crispy_toast CT in CTs)
        {
            if (CT.gameObject.tag.Equals(gameObject.tag))
            {
                self_count += 1;
            }
        }
        if(self_count > 1)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        Debug.Log("show on defeat: " + show_on_defeating_enemy);
        ready = false;
        ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
        DontDestroyOnLoad(this.gameObject);
        bc = GetComponent<BoxCollider2D>();
        collected = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (collected)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            if (SceneManager.GetActiveScene().name != own_scene)
            {
                this.gameObject.SetActive(false);
            }
            else if(show_on_defeating_enemy && !ready){
                this.gameObject.SetActive(false);
            }
            else
            {
                if(show_on_defeating_enemy){
                    Debug.Log("CT ready: " + ready);
                    if(ready){
                        Debug.Log("ruin CT activaed");
                        this.gameObject.SetActive(true);
                    }
                }
                else{
                    this.gameObject.SetActive(true);
                }
            }
            /*
             * if player touches it
             */
            if (bc.IsTouchingLayers(LayerMask.GetMask("Player")))
            {
                ms.AddCT();
                collected = true;
                GameObject.FindGameObjectWithTag("Player").SendMessage("CelebrateOnToast");
                if(bc.tag == "VolcanoToast5")
                {
                    Debug.Log("HELLLOOOOOOOOOOO");
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Scr_PlayerControl>().CS2();
                    //IEnumerator coroutine = delayincutscene();
		            //StartCoroutine(coroutine);;
                }
                //this.gameObject.SetActive(false);
            }
        }
	}
    /*
     * tells whatever calls this fuction if this crispy toast has been collected
     */ 
    public bool Collected()
    {
        return collected;
    }
    //public bool 
    void specialvtoast()
    {
        Debug.Log("HJEEEEELO 2");
        SceneManager.LoadScene("CutScene2");
    }
    private IEnumerator delayincutscene()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("HJEEEEELO 3");
        specialvtoast();
    }
}
