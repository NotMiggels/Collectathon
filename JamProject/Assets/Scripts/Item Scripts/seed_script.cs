using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

public class seed_script : MonoBehaviour {
    private GameObject player;
    private BoxCollider2D myCollider;
    public float dmg;
    public float destruct_countdown;
	// Use this for initialization
	void Start () {
        myCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")) && player != null)
        {
            Debug.Log("player damaged");
            player.SendMessage("TakeDMG", dmg);
            Destroy(gameObject);
        }
        destruct_countdown -= Time.deltaTime;
        if(destruct_countdown <= 0){
            Destroy(gameObject);
        }
	}
}
