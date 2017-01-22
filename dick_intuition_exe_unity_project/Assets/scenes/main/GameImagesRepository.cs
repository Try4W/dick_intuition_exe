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
		var crossdressersImagesPaths = GetResourcesAtPath("textures/cross");
		foreach (string path in crossdressersImagesPaths) {
			Debug.Log ("LoadImagesData: " + path);
			gameImages.Add(CreateGameImageData(path, true));
		}
		var normalImagesPaths = GetResourcesAtPath("textures/normal");
		foreach (string path in normalImagesPaths) {
			Debug.Log ("LoadImagesData: " + path);
			gameImages.Add(CreateGameImageData(path, false));
		}
	}

	private GameImageData CreateGameImageData(string path, bool isCrossdresser) {
		var fileName = path.Substring (path.LastIndexOf ("/")).Replace(".jpg", "");
		var splitedFileName = fileName.Split ('_');

		var folderId = splitedFileName [0]; //  не использую, это только для файловой системы
		var gender = splitedFileName [1];
		var penalty = int.Parse(splitedFileName [2]);
		var reward = int.Parse(splitedFileName [3]);

		return new GameImageData (path, gender == "m", isCrossdresser, penalty, reward);
	}

	private List<string> GetResourcesAtPath(string path) {
		var files = new List<string>();
		string[] fileEntries = Directory.GetFiles(Application.dataPath + "/Resources/" + path);

		foreach (string fileName in fileEntries)
		{
			int assetPathIndex = fileName.IndexOf("Resources");
			string localPath = fileName.Substring(assetPathIndex).Replace("Resources/", "").Replace(".jpg", "");
			if (!localPath.EndsWith (".meta")) {
				files.Add (localPath);
			}
		}

		return files;
	}

}
