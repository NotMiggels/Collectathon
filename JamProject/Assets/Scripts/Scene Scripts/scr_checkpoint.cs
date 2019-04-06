using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_checkpoint : MonoBehaviour {
	public GameObject[] checkpt;
	private GameObject player;
	private float xcoord;
	private float ycoord;
	private BoxCollider2D myCollider;


	// Use this for initialization
	void Start () {
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
		Debug.Log("yikes");
		checkpt[0].SetActive(false);
		checkpt[1].SetActive(true);
	
		myCollider.enabled = !myCollider.enabled;
	}
  }
}
