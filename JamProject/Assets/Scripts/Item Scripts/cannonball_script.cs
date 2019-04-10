using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonball_script : MonoBehaviour{
    
    private Rigidbody2D myrb;
    // Use this for initialization
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(myrb.velocity);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.isTrigger)
        {
            Debug.Log("cannonball collides");
            Debug.Log(collision.collider.gameObject);
            if(collision.collider.gameObject.GetComponent<Scr_PlayerControl>() != null){
                Debug.Log("player takes damage from cannonball");
                collision.collider.gameObject.GetComponent<Scr_PlayerControl>().TakeDMG(10);
            }
            Destroy(gameObject);
        }
    }
}
