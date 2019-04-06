using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_checkpoint : MonoBehaviour {

	public GameObject[] checkpt;
	private GameObject player;
	private BoxCollider2D myCollider;
	public string checkname;
	private master_script ms;
	//Used to identify the checkpoint
	public int sceneid;
	public int checkid;

	// Use this for initialization
	void Start () {

		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		myCollider = GetComponent<BoxCollider2D>();
		checkpt[1].SetActive(false);
		checkpt[0].SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
			
	}
  void OnTriggerEnter2D(Collider2D collision)
  {
	if(collision.gameObject.tag == "Player")
	{
		checkpt[0].SetActive(false);
		checkpt[1].SetActive(true);
		myCollider.enabled = !myCollider.enabled;
		ms.unlockcheckpoint(sceneid, checkid);
		ms.updatelastcheck(sceneid, checkid);
	}
  }
}
