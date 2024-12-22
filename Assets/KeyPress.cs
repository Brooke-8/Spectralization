using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class KeyPress : MonoBehaviour {
	//Initializing regions that keys affect and their renderers
	GameObject keyRegionA;
	GameObject keyRegionS;
	GameObject keyRegionD;
	GameObject keyRegionF;
	SpriteRenderer rendererA;
	SpriteRenderer rendererS;
	SpriteRenderer rendererD;
	SpriteRenderer rendererF;
	public TMP_Text totalScoreString;
	public TMP_Text ScoreStringA;
	public TMP_Text ScoreStringS;
	public TMP_Text ScoreStringD;
	public TMP_Text ScoreStringF;
	public string indicatorColour = "#4A224E3C";
	public string pixelColour = "#DE73A5";
	public static UnityEngine.Color indicatorC;
	public static UnityEngine.Color pixelC;
	public static (int s, int p)[] points;
	public static int totalPoints;


	// Start is called before the first frame update
	void Start() {
		//Finding regions that keys affect and their renderers
		keyRegionA = GameObject.Find("KeyRegion(A)");
		keyRegionS = GameObject.Find("KeyRegion(S)");
		keyRegionD = GameObject.Find("KeyRegion(D)");
		keyRegionF = GameObject.Find("KeyRegion(F)");
		rendererA = keyRegionA.GetComponent<SpriteRenderer>();
		rendererS = keyRegionS.GetComponent<SpriteRenderer>();
		rendererD = keyRegionD.GetComponent<SpriteRenderer>();
		rendererF = keyRegionF.GetComponent<SpriteRenderer>();

		UnityEngine.ColorUtility.TryParseHtmlString(indicatorColour, out indicatorC);
		UnityEngine.ColorUtility.TryParseHtmlString(pixelColour, out pixelC);
		points = new (int, int)[4];
	}

	//Detecting Key Presses
	void Update() {
		//Gameplay Keys
		if (Input.GetKeyDown(KeyCode.A)) {

			StartCoroutine(PointCalculator(0, 16));
			StartCoroutine(ChangeIndicatorColour(rendererA));
			StartCoroutine(FadeScore(ScoreStringA));

		}
		if (Input.GetKeyDown(KeyCode.S)) {
			StartCoroutine(PointCalculator(16, 32));
			StartCoroutine(ChangeIndicatorColour(rendererS));
			StartCoroutine(FadeScore(ScoreStringS));

		}
		if (Input.GetKeyDown(KeyCode.D)) {
			StartCoroutine(PointCalculator(32, 48));
			StartCoroutine(ChangeIndicatorColour(rendererD));
			StartCoroutine(FadeScore(ScoreStringD));

		}
		if (Input.GetKeyDown(KeyCode.F)) {
			StartCoroutine(PointCalculator(48, 64));
			StartCoroutine(ChangeIndicatorColour(rendererF));
			StartCoroutine(FadeScore(ScoreStringF));

		}
		//Back to Start Menu
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
		}



	}
	IEnumerator PointCalculator(int ColumnStart, int ColumnEnd) {
		//Sums the number of pixels that are turned on in each region 
		int sum = 0;
		int perfect = 1;
		int prod = 0;
		float elaspedTime = 0f;
		float countTime = 0.2f;

		while (elaspedTime < countTime) {
			for (int i = ColumnStart; i < ColumnEnd; i++) {
				if (NoteTrigger.subBandLogic[i] == true) {
					perfect++;
				}
				for (int j = 0; j < CreatePixelGrid.grid.GetLength(1); j++) {
					sum += CreatePixelGrid.grid[i, j];
				}
			}
			elaspedTime += Time.deltaTime;
			prod = sum * perfect;
			if (ColumnStart == 0) { ScoreStringA.text = "+" + prod.ToString(); }
			else if (ColumnStart == 16) { ScoreStringS.text = "+" + prod.ToString(); }
			else if (ColumnStart == 32) { ScoreStringD.text = "+" + prod.ToString(); }
			else if (ColumnStart == 48) { ScoreStringF.text = "+" + prod.ToString(); }
			totalPoints += prod;
			totalScoreString.text = totalPoints.ToString();
			Debug.Log(sum.ToString() + "," + perfect.ToString());
			yield return null;
		}



	}
	IEnumerator ChangeIndicatorColour(SpriteRenderer Sr) {

		Sr.color = KeyPress.indicatorC;
		yield return new WaitForSeconds(0.1f);
		Sr.color = new UnityEngine.Color(1f, 1f, 1f, 0f);
	}
	IEnumerator FadeScore(TMP_Text t) {
		float elapsedTime = 0f;
		float fadeTime = 0.5f;

		UnityEngine.Color startColour = new UnityEngine.Color(1f, 1f, 1f, 1f);
		UnityEngine.Color targetColour = new UnityEngine.Color(startColour.r, startColour.g, startColour.b, 0f);

		while (elapsedTime < fadeTime) {
			t.color = UnityEngine.Color.Lerp(startColour, targetColour, elapsedTime / fadeTime);
			elapsedTime += Time.deltaTime;
			yield return null;
		}

		// Ensure the target color is set at the end
		t.color = targetColour;
	}
}
