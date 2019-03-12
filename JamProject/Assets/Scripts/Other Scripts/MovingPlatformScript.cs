using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour {
	public float movetime;
	public float staytime;

	private Rigidbody2D body;

	public GameObject loc1;

	private Vector2 locA;
	private Vector2 org;
	
	private int whichdirect = -1;

	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		locA = loc1.transform.position;
		org = gameObject.transform.position;
		body = gameObject.GetComponent<Rigidbody2D>();
		coroutine = movingtime(whichdirect, movetime);
		StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
	}


	private IEnumerator waittime(float staytime)
	{
		body.velocity = new Vector2(0.0f,0.0f);
		yield return new WaitForSeconds(staytime);
		whichdirect = whichdirect *-1;
		print(whichdirect);
		coroutine = movingtime(whichdirect, movetime);
		StartCoroutine(coroutine);
		
	}

	private IEnumerator movingtime(int cond, float movetime)
	{
		if(cond == -1)
		{
		
			body.velocity = (locA - org) / movetime;
			yield return new WaitForSeconds(movetime);
			coroutine = waittime(staytime);
			StartCoroutine(coroutine);
			
		}
		else
		{

			body.velocity = (org - locA) / movetime;
			yield return new WaitForSeconds(movetime);
			coroutine = waittime(staytime);
			StartCoroutine(coroutine);
			
		}
	}

	
}
