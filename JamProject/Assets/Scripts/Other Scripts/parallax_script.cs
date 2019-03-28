using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_script : MonoBehaviour {

	public bool scrolling, paralax;

	public float backgroundSize;
	public float paralaxSpeed;
	public Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;
	private Vector3 tempVec3 = new Vector3();

	public GameObject bg1;
	public GameObject bg2;
	public GameObject bg3;

	
	// Use this for initialization
	void Start () 
	{
		bg1.transform.position = bg2.transform.position;
		bg3.transform.position = bg2.transform.position;
		Debug.Log(bg1.transform.position);
		Debug.Log(bg2.transform.position);
		Debug.Log(bg3.transform.position);
		bg1.transform.position += new Vector3(-1 * backgroundSize, 0, 0);
		bg3.transform.position += new Vector3( backgroundSize,0, 0);
		Debug.Log(bg1.transform.position);
		Debug.Log(bg2.transform.position);
		Debug.Log(bg3.transform.position);
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;

		layers = new Transform[transform.childCount];
		for(int i = 0; i < transform.childCount; i++)
		{
			layers[i] = transform.GetChild(i);
		}
		leftIndex = 0;
		rightIndex = layers.Length -1;

		
	}

	private void Update()
	{
		if(paralax)
		{
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * paralaxSpeed);
		}
		lastCameraX = cameraTransform.position.x;
		
		if(scrolling)
		{
		if(cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
		{
			ScrollLeft();
		}
		if(cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
		{
			ScrollRight();
		}
		}
	}

	

	private void ScrollLeft()
	{
		int lastLeft = rightIndex;
		layers[rightIndex].position = Vector3.right *(layers[leftIndex].position.x - backgroundSize);
		leftIndex = rightIndex;
		rightIndex --;
		if(rightIndex < 0)
		{
			rightIndex = layers.Length - 1;
		}
	}

	private void ScrollRight()
	{
		int lastLeft = leftIndex;
		layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
		rightIndex = leftIndex;
		leftIndex ++;
		if(leftIndex == layers.Length)
		{
			leftIndex = 0;
		}


	}

}
