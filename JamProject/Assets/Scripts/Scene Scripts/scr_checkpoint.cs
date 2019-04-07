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
	private IEnumerator coroutine;

	//Used to identify the checkpoint
	public int sceneid;
	public int checkid;

	// Use this for initialization
	void Start () {
		
		ms = GameObject.FindGameObjectWithTag("MasterScript").GetComponent<master_script>();
		myCollider = GetComponent<BoxCollider2D>();
		checkpt[1].SetActive(false);
		checkpt[0].SetActive(true);
		checkpt[2].SetActive(false);
		checkpt[3].SetActive(false);
		crossed = 0;
		if(ms.checkpoints[sceneid][checkid] ==1)
		{
			checkpt[0].SetActive(false);
			checkpt[3].SetActive(true);
			checkpt[1].SetActive(false);
			checkpt[2].SetActive(false);
			crossed = 1;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}
  void OnTriggerEnter2D(Collider2D collision)
  {
	//Unlocking new checkpoint
	if(collision.gameObject.tag == "Player" && crossed == 0)
	{
		checkpt[0].SetActive(false);
		checkpt[1].SetActive(true);
		ms.unlockcheckpoint(sceneid, checkid);
		ms.updatelastcheck(sceneid, checkid);
		crossed = 1;
		coroutine = delaytime(1f);
		StartCoroutine(coroutine);

	}
	//Updating checkpoint
	if(collision.gameObject.tag == "Player" && crossed == 1 && ((ms.lastcheckpoint != checkid && ms.lastscene != sceneid)
	|| (ms.lastscene == sceneid && ms.lastcheckpoint != checkid)))
	{
		checkpt[1].SetActive(false);
		checkpt[3].SetActive(false);
		checkpt[2].SetActive(true);
		ms.unlockcheckpoint(sceneid, checkid);
		ms.updatelastcheck(sceneid, checkid);
		coroutine = delayshutdown(1.5f);
		StartCoroutine(coroutine);

	}
  }

  private IEnumerator delayshutdown(float delay)
  {
	yield return new WaitForSeconds(delay);
	checkpt[1].SetActive(false);
	checkpt[3].SetActive(true);
	checkpt[2].SetActive(false);
	
  }
  
  private IEnumerator delaytime(float delay)
  {
	yield return new WaitForSeconds(delay);
	checkpt[1].SetActive(false);
	checkpt[3].SetActive(false);
	checkpt[2].SetActive(true);
	coroutine = delayshutdown(1.5f);
	StartCoroutine(coroutine);
  }
}
