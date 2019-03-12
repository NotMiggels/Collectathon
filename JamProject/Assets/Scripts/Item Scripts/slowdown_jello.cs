using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowdown_jello : MonoBehaviour {
    private GameObject[] enemies;
    public Rigidbody2D jello;
    // Use this for initialization
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy_group1");
        foreach(GameObject e in enemies){
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), e.GetComponent<BoxCollider2D>());
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D jelloclone = (Rigidbody2D)Instantiate(jello, transform.position, transform.rotation);
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), jelloclone.GetComponent<BoxCollider2D>());
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit");
        Destroy(this.gameObject);
    }
}
