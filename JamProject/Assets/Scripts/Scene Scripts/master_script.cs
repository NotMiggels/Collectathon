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

    //Data structures for Checkpoints
    public int[][] checkpoints;
    //What scene to load from
    public int sceneid;
    public int lastscene;
    public int lastcheckpoint;

    //Data structures for 
    public int[][] crouton;
    private int[] crouton_count; 

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

        // Checkpoint setup
        checkpoints = new int[4][];
        for(int i = 0; i < 4; i++)
        {
            int length = 0;
            if(i == 0)
            {
                length = 4;
                checkpoints[0] = new int[4];
            }
            else if(i == 1)
            {
                length = 4;
                checkpoints[1] = new int[4];
            }
            else if(i == 2)
            { 
                length = 3;
                checkpoints[2] = new int[3];
            }
            else if(i == 3)
            { 
                length = 4;
                checkpoints[3] = new int[4];
            }
            for(int j = 0; j < length; j++)
            {
                checkpoints[i][j] = 0;
            }
            checkpoints[i][0] = 1;
            if(i == 2)
            {
                checkpoints[i][0] = 0;
            }
        }

        // Crouton setup
        crouton = new int[4][];
        for(int i = 0; i < 4; i++)
        {
            int length = 0;
            if(i == 0)
            {
                length = 4;
                crouton[0] = new int[50];
            }
            else if(i == 1)
            {
                length = 4;
                crouton[1] = new int[50];
            }
            else if(i == 2)
            { 
                length = 3;
                crouton[2] = new int[50];
            }
            else if(i == 3)
            { 
                length = 4;
                crouton[3] = new int[50];
            }
            for(int j = 0; j < length; j++)
            {
                crouton[i][j] = 0;
            }
        }

        crouton_count = new int[3];
        crouton_count[0] = 0;
        crouton_count[1] = 0;
        crouton_count[2] = 0;



        


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
    public void unlockcheckpoint(int sceneid, int checkid)
    {
        checkpoints[sceneid][checkid] = 1;
    }

    public void updatelastcheck(int sceneid, int checkid)
    {
        lastscene = sceneid;
        lastcheckpoint = checkid;
    }

    public void updatecrouton(int sceneid, int croutonid)
    {
        crouton[sceneid][croutonid] = 1;
    }

    public void croutonAdd(int sceneid)
    {
        crouton_count[sceneid] +=1;
    }

    public int getCrouton(int scene)
    {
        if(scene == 1)
        {
            return crouton_count[1];
        }
        else if (scene == 2)
        {
            return crouton_count[1];
        }
        else if( scene == 4 || scene == 5 || scene == 6)
        {
            return crouton_count[0] + crouton_count[1]+ crouton_count[2];
        }
        else if( scene == 3)
        {
            return crouton_count[2];
        }
        return crouton_count[scene];
    }

    public string gettotcrouton(int scene)
    {
        if(scene == 1)
        {
            return "/100";
        }
        else if (scene == 2)
        {
            return "/100";
        }
        else if( scene == 4 || scene == 5 || scene == 6)
        {
            return "/200";
        }
        return "/50";
    }
    
    
    
    public void StartGame()
    {
        SceneManager.LoadScene("CutScene1");
    }
}
