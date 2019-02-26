using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toast_container : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(this);
        
        int self_count = 0;
        toast_container[] CTs = Resources.FindObjectsOfTypeAll<toast_container>();
        foreach (toast_container CT in CTs)
        {
            if (CT.gameObject.tag.Equals(gameObject.tag))
            {
                self_count += 1;
            }
        }
        if (self_count > 1)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
