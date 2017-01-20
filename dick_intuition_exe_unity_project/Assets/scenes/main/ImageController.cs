using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ImageController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetImage(GameImageData imageData) {
		//Debug.Log ("SetImage: imageData: " + imageData);
		GetComponent<Image> ().sprite = AssetDatabase.LoadAssetAtPath<Sprite>(imageData.assetPath);
	}

}
