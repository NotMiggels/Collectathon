using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeIcon : MonoBehaviour {
	public GameObject talking;
	public GameObject background;
	private Texture bgTex;
	private Texture talkingTex;


	public void changeTalking(string name, GameObject npc){
		if (name == "Jelly") {
			talkingTex = (Texture)Resources.Load("CharIcon/Jelly_icon");
		}
		else{
			string person = npc.GetComponent<SpriteRenderer>().sprite.name;
			if(person == "pic_jarperson1"){
				talkingTex = (Texture)Resources.Load("CharIcon/JP1_icon");
			}
			if(person == "pic_jarperson2"){
				talkingTex = (Texture)Resources.Load("CharIcon/JP2_icon");
			}
			if(person == "pic_jarperson3"){
				talkingTex = (Texture)Resources.Load("CharIcon/JP3_icon");
			}
		}
		talking.GetComponent<RawImage>().texture = talkingTex;
	}

	public void changeBackground(){
		int bgnum = Random.Range(1,6);
		if(SceneManager.GetActiveScene().name == "Village"){
			bgTex = (Texture)Resources.Load("Backgrounds/Village" + bgnum);
		}
		if(SceneManager.GetActiveScene().name == "JungleScene"){
			bgTex = (Texture)Resources.Load("Backgrounds/Jungle" + bgnum);
		}
		if(SceneManager.GetActiveScene().name == "VolcanoScene"){
			bgTex = (Texture)Resources.Load("Backgrounds/Volcano" + bgnum);
		}
		background.GetComponent<RawImage>().texture = bgTex;
	}
}
