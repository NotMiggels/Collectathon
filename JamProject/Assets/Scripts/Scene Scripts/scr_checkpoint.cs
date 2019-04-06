using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_checkpoint : MonoBehaviour {
	public GameObject[] checkpt;
	private GameObject player;
	private float xcoord;
	private float ycoord;
	private BoxCollider2D myCollider;
	private Animation crossed;

	// Use this for initialization
	void Start () {
		 myCollider = GetComponent<BoxCollider2D>();
		checkpt[1].SetActive(false);
		checkpt[0].SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && player != null)
        {
			Debug.Log("yikes");
			checkpt[0].SetActive(false);
			checkpt[1].SetActive(true);
			crossed["crossedcheckpt"].wrapMode = WrapMode.Once;
			crossed.Play("crossedcheckpt");

		}
	}
}
