using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGeyser : MonoBehaviour {
	public float delaytime;
	private BoxCollider2D myCollider;
	private IEnumerator coroutine;
	private GameObject player;


	// Use this for initialization
	void Start () {
		myCollider = GetComponent<BoxCollider2D>();
		coroutine = delayaction(delaytime);
		StartCoroutine(coroutine);

	}
	
	// Update is called once per frame
	void Update () {
		 if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && player != null)
		 {
			   player.SendMessage("TakeDMG", 10);
		 }
	}


	private IEnumerator delayaction(float delay)
	{
		yield return new WaitForSeconds(delay);
	}

	private IEnumerator geyserattack(float time)
	{
		yield return new WaitForSeconds(time);
	}

}
