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
		enemylist = new List<GameObject>();
		Debug.Log(enemylist.Count);
		stateofportal[0].SetActive(true);
		stateofportal[1].SetActive(false);
		coroutine = spawnenemy(delay);
		StartCoroutine(coroutine);
	}
	
	//Spawn Random Enemy every delay seconds 
	private IEnumerator spawnenemy(float delay)
	{
		Debug.Log("start spawn coroutine");
		yield return new WaitForSeconds(delay);
		if(enemylist.Count < spawnsize)
		{
			Debug.Log("try to spawn");
			stateofportal[0].SetActive(false);
			stateofportal[1].SetActive(true);
			int enemyrng =  (int)Random.Range(0, 3);
			GameObject enemy;
			enemy = Instantiate(enemyid[enemyrng], gameObject.transform.position, transform.rotation);
			enemylist.Add(enemy);
			Debug.Log("enemy spawned?");
			yield return new WaitForSeconds(2.0f);
			stateofportal[0].SetActive(true);
			stateofportal[1].SetActive(false);
		}
		coroutine = spawnenemy(delay);
		StartCoroutine(coroutine);
	}

}
