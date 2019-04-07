using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnlocationdata : MonoBehaviour {

	//Script that just holds spawn location data

	private Vector2[][] locdata;
	// Use this for initialization
	void Start () {
		locdata = new Vector2[3][];
		locdata[0] = new Vector2[3];
		locdata[1] = new Vector2[3];
		locdata[2] = new Vector2[3];

		//Initailize all the location data

		//Jungle

		locdata[0][0] = new Vector2(-0.32f,0.441f);
		locdata[0][1] = new Vector2(3,3);
		locdata[0][2] = new Vector2(3,3);

		//Volcano

		locdata[1][0] = new Vector2(2,2);
		locdata[1][1] = new Vector2(3,3);
		locdata[1][2] = new Vector2(3,3);


		//Inside volcano

		locdata[2][0] = new Vector2(2,2);
		locdata[2][1] = new Vector2(3,3);
		locdata[2][2] = new Vector2(3,3);

		//Final Level

		locdata[3][0] = new Vector2(2,2);
		locdata[3][1] = new Vector2(3,3);
		locdata[3][2] = new Vector2(3,3);
	}

	public Vector2[][] returndata()
	{
		return locdata;
	}
}
