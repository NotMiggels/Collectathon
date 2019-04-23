using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelName : MonoBehaviour {

	public float fadeTime;

	void Start(){
		Fade();
	}

	public void Fade(){
		StartCoroutine(FadeRoutine());
	}
	public void FadeOut(){

	}
	private IEnumerator FadeRoutine(){
		Text text = GetComponent<Text>();
		//Color ogColor = text.color;
		for (float t = 0.01f; t < fadeTime; t += Time.deltaTime) {
			text.color = Color.Lerp(Color.clear, Color.black, Mathf.Min(1, t/fadeTime));
			yield return null;
		}
		yield return new WaitForSeconds(fadeTime*3);
		for (float t = 0.01f; t < fadeTime; t += Time.deltaTime) {
			text.color = Color.Lerp(Color.black, Color.clear, Mathf.Min(1, t/fadeTime));
			yield return null;
		}
	}
}
