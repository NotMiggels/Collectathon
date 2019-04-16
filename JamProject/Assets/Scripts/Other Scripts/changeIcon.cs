using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeIcon : MonoBehaviour {
	public GameObject talking;
	public GameObject background;
	private Texture bgTex;
	private Texture talkingTex;
	private string[] jp1names;
	private string[] jp2names;
	private string[] jp3names;

	void Start () {
		jp1names = new string[] {"Jar Guy", "Jar Boy"};
		jp2names = new string[] {"Jar Gal", "Jar Girl"};
		jp3names = new string[] {"Jar Women", "Jar Woman"};
	}


	public void changeTalking(string name, GameObject npc){
		if (name == "Jelly") {
			talkingTex = (Texture)Resources.Load("CharIcon/Jelly_icon");
		}
		if (jp1names.Contains(name)){
			talkingTex = (Texture)Resources.Load("CharIcon/JP1_icon");
		}
		if(jp2names.Contains(name)){
			talkingTex = (Texture)Resources.Load("CharIcon/JP2_icon");
		}
		if(jp3names.Contains(name)){
			talkingTex = (Texture)Resources.Load("CharIcon/JP3_icon");
		}
		if (name == "Squasher") {
			talkingTex = (Texture)Resources.Load("CharIcon/Squasher_icon");
		}
		if (name == "Badnana") {
			talkingTex = (Texture)Resources.Load("CharIcon/Badnana_icon");
		}
		if (name == "Deity") {
			talkingTex = (Texture)Resources.Load("CharIcon/Deity_icon");
		}
		else{
			Debug.Log(name);
		}
		talking.GetComponent<RawImage>().texture = talkingTex;
	}

	public void changeBackground(){
		int bgnum = Random.Range(1,6);
		if(SceneManager.GetActiveScene().name == "Village"){
			bgTex = (Texture)Resources.Load("Backgrounds/Village" + bgnum);
		}
		if(SceneManager.GetActiveScene().name == "Temple 1"){
			bgTex = (Texture)Resources.Load("Backgrounds/Temple");
		}
		if(SceneManager.GetActiveScene().name == "JungleScene"){
			bgTex = (Texture)Resources.Load("Backgrounds/Jungle" + bgnum);
		}
		if(SceneManager.GetActiveScene().name == "VolcanoScene"){
			bgTex = (Texture)Resources.Load("Backgrounds/Volcano" + bgnum);
		}
		if(SceneManager.GetActiveScene().name == "InsideVolcanoScene"){
			bgTex = (Texture)Resources.Load("Backgrounds/VolcIn" + bgnum);
		}
		background.GetComponent<RawImage>().texture = bgTex;
	}
}
