using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tomato_sprite_script : MonoBehaviour {
    public GameObject tomato;
    private SpriteRenderer sr;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Die(){
        Destroy(tomato);
    }
    public void Attack(){
        tomato.SendMessage("Attack");
    }
    public void EndAttack(){
        tomato.SendMessage("EndAttack");
    }
}
