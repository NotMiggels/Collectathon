using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pepper_flame_script : MonoBehaviour {
    public GameObject[] flame_sprites;
    public float flame_interval;
    //the gap between each frame of "flame animation
    private float flame_countdown;
    private IEnumerator coroutine;
    private int sprite_count;
    private pepper_script parent;

	// Use this for initialization
	void Start () {
        sprite_count = flame_sprites.Length;
        foreach (GameObject flame in flame_sprites){
            flame.SetActive(false);
        }
        coroutine = Activate(0);
        StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private IEnumerator Activate(int index){
        flame_sprites[index].SetActive(true);
        yield return new WaitForSecondsRealtime(flame_interval);
        flame_sprites[index].SetActive(false);
        index += 1;
        if (index == sprite_count)
        {   
            parent.EndAttack();
            Destroy(gameObject);
        }
        else
        {
            coroutine = Activate(index);
            StartCoroutine(coroutine);
        }
    }
    public void SetParent(pepper_script o){
        parent = o;
    }
}
