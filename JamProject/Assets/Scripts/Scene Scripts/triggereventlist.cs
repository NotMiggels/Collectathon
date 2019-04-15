using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggereventlist : MonoBehaviour {
	public GameObject[] portals;

	private GameObject player;
	private Scr_PlayerControl player_script;

	
	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag("Player");
		player_script = player.GetComponent<Scr_PlayerControl>();
		for(int i = 0; i < portals.Length; i++)
		{
			portals[i].SetActive(false);
		}

	}
	
	// Update is called once per frame

	//unlock the portal1
	public void unlockjungle()
	{
		portals[0].SetActive(true);

	}
	//unlock the portal2 and ability 1
	public void unlockspicyvolcano()
	{
		portals[1].SetActive(true);
		player_script.ability_count +=1;
	}

	//unlock the portal3 and ability 2
	public void unlockcheesemoon()
	{
		portals[2].SetActive(true);
		player_script.ability_count +=1;
	}

}
