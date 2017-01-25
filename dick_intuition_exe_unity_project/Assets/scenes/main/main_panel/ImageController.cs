using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour {
	
	private Action lastAction;

	public void FadeIn(Action action) {
		if(lastAction != null) throw new Exception("trying to FadeIn() while animation already playing");
		GetComponent<Animator>().SetTrigger("fadeIn");
		lastAction = action;
	}

	public void FadeOut(Action action) {
		if(lastAction != null) throw new Exception("trying to FadeOut() while animation already playing");
		GetComponent<Animator>().SetTrigger("fadeOut");
		lastAction = action;
	}

	public void OnAnimationFinished() {
		Debug.Log("OnAnimationFinished");
		if(lastAction == null) return;
		var lastActionTmp = lastAction;
		lastAction = null;
		lastActionTmp.Invoke();
	}

	public void SetImage(GameImageData imageData) {
		Debug.Log ("SetImage: imageData: " + imageData);
		var sprite = Resources.Load<Sprite>("images/" + imageData.assetName);
		if(sprite == null) throw new NullReferenceException("sprite is null");
		GetComponent<Image>().sprite = sprite;
	}

}
