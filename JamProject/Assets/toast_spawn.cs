using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toast_spawn : MonoBehaviour {
    public GameObject[] enemies;
    public GameObject toast;
    private bool toast_ready;
    private bool toast_displayed;
	// Use this for initialization
	void Start () {
        toast_ready = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(toast != null){
            toast_ready = true;
            for (int a = 0; a < enemies.Length; a++)
            {
                if (enemies[a] != null)
                {
                    toast_ready = false;
                    break;
                }
            }
            if (toast.GetComponent<crispy_toast>().show_on_defeating_enemy && toast_ready && !toast_displayed)
            {
                toast.GetComponent<crispy_toast>().ready = true;
                toast.SetActive(true);
                toast_displayed = true;
            }
        }

	}
}
