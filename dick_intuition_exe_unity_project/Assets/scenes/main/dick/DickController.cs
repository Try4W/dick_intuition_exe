using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DickController : MonoBehaviour {

	[SerializeField]
	private GameObject dickImageGo;
	[SerializeField]
	private GameObject increaseTextGo;
	[SerializeField]
	private GameObject decreaseTextGo;
	[SerializeField]
	private Text currentSizeText;
	[SerializeField]
	private AudioSource hitSoundAudioSource;
	[SerializeField]
	private AudioSource healSoundAudioSource;

	private int _currentSize = 10;
	public int currentSize {
		get { return _currentSize; }
	}

	void Start () {
		UpdateImageAndText();
	}
	
	void Update () {
		
	}

	public void Increase(int amount) {
		Debug.Log ("Increase: " + amount);
		_currentSize += amount;
		if(_currentSize > 19) _currentSize = 19;
		UpdateImageAndText();
		dickImageGo.GetComponent<Animator>().SetTrigger("heal");
		increaseTextGo.GetComponent<Animator>().SetTrigger("riseUp");
		increaseTextGo.GetComponent<Text>().text = "+" + amount;
		healSoundAudioSource.Play();
	}

	public void Decrease(int amount) {
		Debug.Log ("Decrease: " + amount);
		_currentSize -= amount;
		if(_currentSize < 0) _currentSize = 0;
		UpdateImageAndText();
		dickImageGo.GetComponent<Animator>().SetTrigger("takeDamage");
		decreaseTextGo.GetComponent<Animator>().SetTrigger("goDown");
		decreaseTextGo.GetComponent<Text>().text = "-" + amount;
		hitSoundAudioSource.Play();
	}

	private void UpdateImageAndText() {
		Debug.Log("UpdateImage: currentSize: " + currentSize);
		var sprite = Resources.Load<Sprite>("textures/dick_sizes/" + currentSize);
		if(sprite == null) throw new NullReferenceException("sprite is null");
		dickImageGo.GetComponent<Image>().sprite = sprite;

		currentSizeText.text = currentSize + "см";
	}

}
