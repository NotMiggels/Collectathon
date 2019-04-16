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
	private string[] jp1names = new string[] {"Jar Guy", "Jar Boy"};
	private string[] jp2names = new string[] {"Jar Gal", "Jar Girl"};
	private string[] jp3names = new string[] {"Jar Women", "Jar Woman"};

	public void changeTalking(string name){
		Debug.Log(name);
		Debug.Log(jp1names);
		if (name == "Jelly") {
			talkingTex = (Texture)Resources.Load("CharIcon/Jelly_icon");
		}
		else if (jp1names.Contains(name)){
			talkingTex = (Texture)Resources.Load("CharIcon/JP1_icon");
		}
		else if(jp2names.Contains(name)){
			talkingTex = (Texture)Resources.Load("CharIcon/JP2_icon");
		}
		else if(jp3names.Contains(name)){
			talkingTex = (Texture)Resources.Load("CharIcon/JP3_icon");
		}
		else if (name == "Jarvis") {
			talkingTex = (Texture)Resources.Load("CharIcon/Jarvis_icon");
		}
		else if (name == "Squasher") {
			talkingTex = (Texture)Resources.Load("CharIcon/Squasher_icon");
		}
		else if (name == "Badnana") {
			talkingTex = (Texture)Resources.Load("CharIcon/Badnana_icon");
		}
		else if (name == "Deity") {
			talkingTex = (Texture)Resources.Load("CharIcon/Deity_icon");
		}
		else if (name == "Morbid Morbier") {
			talkingTex = (Texture)Resources.Load("CharIcon/MM_icon");
		}
		else{
			Debug.Log(name + " doesn't exist");
		}
		talking.GetComponent<RawImage>().texture = talkingTex;
	}

	public void changeBackground(){
		int bgnum = Random.Range(1,6);
		if(SceneManager.GetActiveScene().name == "Jarvis'sHouse"){
			bgTex = (Texture)Resources.Load("Backgrounds/JarvisHouse");
		}
		else if(SceneManager.GetActiveScene().name == "Village"){
			bgTex = (Texture)Resources.Load("Backgrounds/Village" + bgnum);
		}
		else if(SceneManager.GetActiveScene().name == "Temple 1"){
			bgTex = (Texture)Resources.Load("Backgrounds/Temple");
		}
		else if(SceneManager.GetActiveScene().name == "JungleScene"){
			bgTex = (Texture)Resources.Load("Backgrounds/Jungle" + bgnum);
		}
		else if(SceneManager.GetActiveScene().name == "VolcanoScene"){
			bgTex = (Texture)Resources.Load("Backgrounds/Volcano" + bgnum);
		}
		else if(SceneManager.GetActiveScene().name == "InsideVolcanoScene"){
			bgTex = (Texture)Resources.Load("Backgrounds/VolcIn" + bgnum);
		}
		else if(SceneManager.GetActiveScene().name == "FinalLevel"){
			bgTex = (Texture)Resources.Load("Backgrounds/Bossroom");
		}
		background.GetComponent<RawImage>().texture = bgTex;
	}
}
