using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameImageData {

	public string assetName;
	public bool isMale;
	public bool isCrossdresser;
	public int penalty;
	public int reward;

	public GameImageData(string assetName, bool isMale, bool isCrossdresser, int penalty, int reward) {
		this.assetName = assetName; 
		this.isMale = isMale;
		this.isCrossdresser = isCrossdresser;
		this.isCrossdresser = isCrossdresser;
		this.penalty = penalty;
		this.reward = reward;
	}

	public override string ToString() {
		return "GameImage{assetName=" + assetName + ", isMale=" + isMale + ", isCrossdresser=" 
			+ isCrossdresser + ", penalty=" + penalty + ", reward=" + reward;
	}

}
