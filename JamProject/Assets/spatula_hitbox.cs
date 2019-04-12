using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spatula_hitbox : MonoBehaviour {
    private BoxCollider2D myCollider;
    private GameObject player;
    // Use this for initialization
    void Start () {
        myCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void InflictDamage()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && player != null)
        {
            //Debug.Log("player damaged");
            player.SendMessage("TakeDMG", 10);
        }
    }
}
