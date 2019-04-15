using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggereventlist : MonoBehaviour {
	public GameObject[] portals;

	private GameObject player;
	private Scr_PlayerControl player_script;
    private GameObject ms;
	
	// Use this for initialization
	void Start () {
        ms = GameObject.FindGameObjectWithTag("MasterScript");
		player = GameObject.FindGameObjectWithTag("Player");
		player_script = player.GetComponent<Scr_PlayerControl>();
        int[] portal_status = ms.GetComponent<master_script>().GetPortalStatus();
		for(int i = 0; i < portals.Length; i++)
		{
            if(portal_status[i] == 0){
                portals[i].SetActive(false);

            }
            else{
                portals[i].SetActive(true);

            }
		}

	}
	
	// Update is called once per frame

	//unlock the portal1
	public void Unlockjungle()
	{
		portals[0].SetActive(true);
        ms.GetComponent<master_script>().ActivatePortal(0);
	}
	//unlock the portal2 and ability 1
	public void Unlockspicyvolcano()
	{
		portals[1].SetActive(true);
        ms.GetComponent<master_script>().ActivatePortal(1);

        ms.GetComponent<master_script>().JellyAbilityCountPlus();
	}

	//unlock the portal3 and ability 2
	public void Unlockcheesemoon()
	{
		portals[2].SetActive(true);
        ms.GetComponent<master_script>().ActivatePortal(2);

        ms.GetComponent<master_script>().JellyAbilityCountPlus();
	}

}
