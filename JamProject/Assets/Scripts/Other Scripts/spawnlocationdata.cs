using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnlocationdata : MonoBehaviour {

	//Script that just holds spawn location data

	private Vector2[][] locdata;
	// Use this for initialization
	void Start () {
		locdata = new Vector2[4][];
		locdata[0] = new Vector2[4];
		locdata[1] = new Vector2[4];
		locdata[2] = new Vector2[3];
		locdata[3] = new Vector2[4];

		//Initailize all the location data

		//Jungle

		locdata[0][0] = new Vector2(-0.32f,0.441f);
		locdata[0][1] = new Vector2(13.06218f,4.276f);
		locdata[0][2] = new Vector2(27.342f,-1.458f);
		locdata[0][3] = new Vector2(56.10296f,5.02f);

		//Volcano

		locdata[1][0] = new Vector2(0f,.44f);
		locdata[1][1] = new Vector2(-6.7741f,9.517f);
		locdata[1][2] = new Vector2(12.68f, 5.605f);
		locdata[1][3] = new Vector2(1.479f,16.531f);

		//Inside volcano

		locdata[2][0] = new Vector2(0.598f,20.375f);
		locdata[2][1] = new Vector2(6.973f,3.694f);
		locdata[2][2] = new Vector2(-8.620561f,0.223f);

		//Final Level

		locdata[3][0] = new Vector2(-0.32f,0.295f);
		locdata[3][1] = new Vector2(-2.044f, 8.473f);
		locdata[3][2] = new Vector2(-2.054245f,13.684f);
		locdata[3][3] = new Vector2(12.109f, 38.518f);

	}

	public Vector2[][] returndata()
	{
		return locdata;
	}
}
