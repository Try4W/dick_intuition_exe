using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameImagesRepository gameImagesRepository;
	public ImageController imageController;
	public DickController dickController;
	public MainPanelController mainPanelController;

	[SerializeField]
	private Button sexButton;
	[SerializeField]
	private Button denyButton;

	private List<GameImageData> usedGameImages = new List<GameImageData>();
	private List<GameImageData> unusedGameImages = new List<GameImageData>();

	private GameImageData currentGameImage;

	void Start () {
		sexButton.onClick.AddListener(() => PickSex());
		denyButton.onClick.AddListener(() => PickDeny());
		gameImagesRepository.Init ();
		mainPanelController.ShowGamePanel();
		NewGame ();
	}

	void Update () {
		
	}

	private void NewGame() {
		Debug.Log ("newGame");
		usedGameImages.Clear ();
		unusedGameImages.Clear ();
		unusedGameImages.AddRange (gameImagesRepository.gameImages);
		
		sexButton.enabled = false;
		denyButton.enabled = false;
		ShowNextPicutre ();
	}

	private void PickSex() {
		Debug.Log ("PickSex");
		if (currentGameImage.isMale) {
			dickController.Decrease (currentGameImage.penalty);
		} else {
			dickController.Increase (currentGameImage.reward);
		}
		NextGameStep ();
	}


	private void PickDeny() {
		Debug.Log ("PickDeny");
		if (currentGameImage.isMale) {
			dickController.Increase (currentGameImage.reward);
		} else {
			dickController.Decrease (currentGameImage.penalty);
		}
		NextGameStep ();
	}

	private void NextGameStep() {
		sexButton.enabled = false;
		denyButton.enabled = false;
		imageController.FadeOut(() => {
			if (unusedGameImages.Count == 0) {
				FinishGame ();
			} else {
				ShowNextPicutre();
			}
		});
	}

	private void FinishGame() {
		if(dickController.currentSize > 10) {
			WinGame();
		} else {
			OverGame();
		}
	}

	private void WinGame() {
		mainPanelController.ShowGameWinPanel();
	}

	private void OverGame() {
		mainPanelController.ShowGameOverPanel();
	}

	private void ShowNextPicutre() {
		var newGameImageData = unusedGameImages [Random.Range (0, unusedGameImages.Count)];
		this.currentGameImage = newGameImageData;
		unusedGameImages.Remove (newGameImageData);

		imageController.SetImage (newGameImageData);
		imageController.FadeIn(() => {
			sexButton.enabled = true;
			denyButton.enabled = true;
		});
		// Debug.Log ("ShowNextPicutre: " + unusedGameImages.Count);
	}

}
