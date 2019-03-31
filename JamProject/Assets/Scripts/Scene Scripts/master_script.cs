using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class master_script : MonoBehaviour {
    public float jelly_init_health;
    public float jelly_init_gauge;
    public Dialogue[] dialogues;
    public int[] dialogue_CT_count;
    private int dialogue_index;
    private int dialogue_index_max;
    private bool predefined_spawn;
    private float spawn_x;
    private float spawn_y;
    private int ct_count;//ct stands for crispy toast
    private float jelly_health;
    private float jelly_gauge; //ability gauge
    private static master_script ms;
    private UI_healthbar UI_manager;

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
        jelly_health = jelly_init_health;
        jelly_gauge = jelly_init_gauge;
        ct_count = 0;
        DontDestroyOnLoad(this.gameObject);
        dialogue_index_max = dialogues.Length;
        dialogue_index = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("CT count: " + ct_count);
        if(dialogue_index < dialogue_index_max){
            if (ct_count == dialogue_CT_count[dialogue_index])
            {
                UI_manager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UI_healthbar>();
                UI_manager.ShowDialogueBox();
                FindObjectOfType<DialogueManager>().StartDialogue(dialogues[dialogue_index], gameObject);
                dialogue_index += 1;
            }  
        }

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
    public void setJellyHealth(float hp)
    {
        jelly_health = hp;
    }
    public float getJellyHealth()
    {
        return jelly_health;
    }
    public void setJellyGauge(float gauge)
    {
        jelly_gauge = gauge;
    }
    public float getJellyGauge()
    {
        return jelly_gauge;
    }
    public void setSpawnLocation(float x, float y)
    {
        spawn_x = x;
        spawn_y = y;
    }
    public Vector3 getSpawnLocation()
    {
        return new Vector3(spawn_x, spawn_y);
    }
    public void set_definedSpawn(bool b)
    {
        predefined_spawn = b;
    }
    public bool get_definedSpawn()
    {
        return predefined_spawn;
    }
}
