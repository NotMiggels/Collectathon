using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyportal_scr : MonoBehaviour {
	private List<GameObject> enemylist;
	public GameObject[] enemyid;
	public GameObject[] stateofportal;
	public float delay;
	public int spawnsize;
	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		stateofportal[0].SetActive(true);
		stateofportal[1].SetActive(false);
		coroutine = spawnenemy(delay);
		StartCoroutine(coroutine);
	}
	
	//Spawn Random Enemy every delay seconds 
	private IEnumerator spawnenemy(float delay)
	{
		yield return new WaitForSeconds(delay);
		if(enemylist.Count < spawnsize)
		{
			int enemyrng =  (int)Random.Range(0, 3);
			GameObject enemy;
			enemy = Instantiate(enemyid[enemyrng], gameObject.transform.position, transform.rotation);
			enemylist.Add(enemy);
		}
		coroutine = spawnenemy(delay);
		StartCoroutine(coroutine);
	}

}
