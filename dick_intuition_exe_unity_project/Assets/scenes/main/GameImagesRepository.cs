using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameImagesRepository : MonoBehaviour {

	public List<GameImageData> gameImages = new List<GameImageData>();

	public void Init() {
		LoadImagesData ();
	}

	private void LoadImagesData() {
		var json = Resources.Load<TextAsset>("images_data");
		var imagesDataFromJson = JsonHelper.GetJsonArray<GameImageData>(json.text);
		gameImages.AddRange(imagesDataFromJson);
	}

}
