using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax_script : MonoBehaviour {

	public bool parax;

	public float backgroundSize;
	public float paralaxSpeed;
	public GameObject backg1;
	public GameObject backg2;
	public GameObject backg3;
	public Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;
	private Vector3 tempVec3 = new Vector3();
	
	// Use this for initialization
	void Start () 
	{
		
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
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * paralaxSpeed);
		lastCameraX = cameraTransform.position.x;
		
		if(cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
		{
			ScrollLeft();
		}
		if(cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
		{
			ScrollRight();
		}
		
		
	}

	void LateUpdate()
	{
		tempVec3.x = backg1.transform.position.x;
    	tempVec3.y = cameraTransform.position.y;
 		tempVec3.z =  backg1.transform.position.z;
    	backg1.transform.position = tempVec3;
		tempVec3.x = backg2.transform.position.x;
    	tempVec3.y = cameraTransform.position.y;
 		tempVec3.z =  backg2.transform.position.z;
    	backg2.transform.position = tempVec3;
		tempVec3.x = backg3.transform.position.x;
    	tempVec3.y = cameraTransform.position.y;
 		tempVec3.z =  backg3.transform.position.z;
    	backg3.transform.position = tempVec3;

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
