using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelController : MonoBehaviour {

	[SerializeField]
	private GameObject gamePanelGo;
	[SerializeField]
	private GameObject gameWinPanelGo;
	[SerializeField]
	private GameObject gameOverPanelGo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowGamePanel() {
		gamePanelGo.SetActive(true);
		gameWinPanelGo.SetActive(false);
		gameOverPanelGo.SetActive(false);
	}

	public void ShowGameWinPanel() {
		gamePanelGo.SetActive(false);
		gameWinPanelGo.SetActive(true);
		gameOverPanelGo.SetActive(false);
	}

	public void ShowGameOverPanel() {
		gamePanelGo.SetActive(false);
		gameWinPanelGo.SetActive(false);
		gameOverPanelGo.SetActive(true);
	}

}
