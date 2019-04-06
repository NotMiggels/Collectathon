using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGeyser : MonoBehaviour {
	public GameObject[] geyser;
	public float fire_interv;
	private int sprite_count;
	public float delaytime;
	private BoxCollider2D myCollider;
	private IEnumerator coroutine;
	private GameObject player;
	public float duration;
	public float lastingtime;
	


	// Use this for initialization
	void Start () {
		sprite_count = geyser.Length;
		myCollider = GetComponent<BoxCollider2D>();
        foreach (GameObject flame in geyser){
            flame.SetActive(false);
        }
		coroutine = delayaction(delaytime);
		StartCoroutine(coroutine);

	}
	
	// Update is called once per frame
	void Update () {
	}


	private IEnumerator delayaction(float delay)
	{
		yield return new WaitForSeconds(delay);
		coroutine = geyserattack(0);
    	StartCoroutine(coroutine);
	}

	private IEnumerator geyserattack(int index)
	{
		float deelay = 0;
        geyser[index].SetActive(true);
		if(index == sprite_count)
		{
			deelay = duration;
		}
        yield return new WaitForSecondsRealtime(fire_interv + deelay);
		deelay = 0;
		if (index == sprite_count-1)
        { 
			yield return new WaitForSecondsRealtime(lastingtime);
		} 
        geyser[index].SetActive(false);
		geyser[index].GetComponent<FireGeyser2>().damaged = false;
        index += 1;
        if (index == sprite_count)
        {   
			index = 0;
            yield return new WaitForSecondsRealtime(duration);
			coroutine = geyserattack(index);
            StartCoroutine(coroutine);
        }
        else
        {
            coroutine = geyserattack(index);
            StartCoroutine(coroutine);
        }
    }

}

