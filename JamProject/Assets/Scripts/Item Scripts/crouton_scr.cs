using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crouton_scr : MonoBehaviour {

	private master_script ms;
    private BoxCollider2D myCollider;
	public int sceneid;
	public int croutonid;
	// Use this for initialization
	void Start () {

		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		myCollider = GetComponent<BoxCollider2D>();
		
	}
	
	// Update is called once per frame
	

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			ms.croutonAdd(sceneid);
			ms.updatecrouton(sceneid, croutonid);
			Destroy(this);
		}
	}
}
