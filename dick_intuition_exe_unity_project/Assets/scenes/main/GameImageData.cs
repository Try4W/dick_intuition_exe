using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameImageData {

	public string assetPath;
	public bool isMale;
	public bool isCrossdresser;
	public int penalty;
	public int reward;

	public GameImageData(string assetPath, bool isMale, bool isCrossdresser, int penalty, int reward) {
		this.assetPath = assetPath; 
		this.isMale = isMale;
		this.isCrossdresser = isCrossdresser;
		this.isCrossdresser = isCrossdresser;
		this.penalty = penalty;
		this.reward = reward;
	}

	public override string ToString() {
		return "GameImage{assetPath=" + assetPath + ", isMale=" + isMale + ", isCrossdresser=" 
			+ isCrossdresser + ", penalty=" + penalty + ", reward=" + reward;
	}

}
