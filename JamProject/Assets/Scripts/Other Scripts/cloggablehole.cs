using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloggablehole : MonoBehaviour {
	public GameObject[] holestate;
	private BoxCollider2D m_Collider;

	// Use this for initialization
	void Start () {
		holestate[1].SetActive(false);
		holestate[0].SetActive(true);
		
		m_Collider = gameObject.GetComponent<BoxCollider2D>();
		m_Collider.enabled = true;
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void change()
	{
		holestate[1].SetActive(true);
		holestate[0].SetActive(false);
		m_Collider.enabled = !m_Collider.enabled;
	}
}
