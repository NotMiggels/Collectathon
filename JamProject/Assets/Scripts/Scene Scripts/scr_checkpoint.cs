using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_checkpoint : MonoBehaviour {

	public GameObject[] checkpt;
	private GameObject player;
	private BoxCollider2D myCollider;
	public string checkname;
	private master_script ms;
	public int crossed;
	private Component halo;

	//Used to identify the checkpoint
	public int sceneid;
	public int checkid;

	// Use this for initialization
	void Start () {
		halo = GetComponent("Halo");
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		myCollider = GetComponent<BoxCollider2D>();
		checkpt[1].SetActive(false);
		checkpt[0].SetActive(true);
		crossed = 0;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
  void OnTriggerEnter2D(Collider2D collision)
  {
	if(collision.gameObject.tag == "Player" && crossed == 0)
	{
		checkpt[0].SetActive(false);
		checkpt[1].SetActive(true);
		ms.unlockcheckpoint(sceneid, checkid);
		ms.updatelastcheck(sceneid, checkid);
		crossed = 1;
	}
	if(collision.gameObject.tag == "Player" && crossed == 1 && ((ms.lastcheckpoint != checkid && ms.lastscene != sceneid)
	|| (ms.lastscene == sceneid && ms.lastcheckpoint != checkid)))
	{
		ms.unlockcheckpoint(sceneid, checkid);
		ms.updatelastcheck(sceneid, checkid);
		halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
		
		

	}
  }

  private IEnumerator delayshutdown(float delay)
  {
	 yield return new WaitForSeconds(delay);
	halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
	 
  }
}
