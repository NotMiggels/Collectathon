using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_cutscene1 : MonoBehaviour {
	public GameObject[] comic;
	private int sprite_count;
	private int index = 0;
	public string scenetransition;
	public int fire;
	private master_script ms;
	// Use this for initialization
	void Start () {
		sprite_count = comic.Length;
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		foreach (GameObject panel in comic){
            panel.SetActive(false);
        }
		comic[0].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("space"))
		{
			comic[index].SetActive(false);
			index +=1;
			if(index == comic.Length)
			{
				if(fire == 1)
				{
					ms.set_definedSpawn(true);
					ms.setSpawnLocation(0.846f,30.737f);
				}
				SceneManager.LoadScene(scenetransition);
			}
			else
			{
				comic[index].SetActive(true);
			}
			
		}
	}
}
