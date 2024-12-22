using Unity.VisualScripting;
using UnityEngine;

public class NoteTrigger : MonoBehaviour {
	public AudioSource spectrumSource;
	private int numSamples = 1024;
	private int subBands = 64;
	private int historySize = 43;
	const float a = 1.00395550808f;
	const float b = 1.27090642553f;
	public float C = 1.2f;
	private float[] subbandWidths;
	private float[] spectrumData;
	private float[] Es;
	private float[][] Ei;
	public static bool[] subBandLogic;
	public static float lerpSpeed = 10f;

	int samplesSinceLastBeat = 0;


	void Start() {
		//Set up arrays
		spectrumData = new float[numSamples];
		subBandLogic = new bool[subBands];
		Es = new float[subBands];
		Ei = new float[subBands][];
		for (int i = 0; i < subBands; i++) {
			Ei[i] = new float[historySize];
		}

		//Compute Subband Widths
		subbandWidths = new float[subBands];
		float sum = 0.0f;
		for (int i = 0; i < subBands; i++) {
			subbandWidths[i] = a * (b + i);
			//Debug.Log("subbandwidths 1: " + subbandWidths[i]);
			sum += subbandWidths[i];
		}
		for (int i = 0; i < subBands; i++) {
			subbandWidths[i] = (subbandWidths[i] / sum) * numSamples;
			//Debug.Log("subbandwidths 2: " + subbandWidths[i]);
		}
		float samplingRate = 44100.0f;
		for (int i = 0; i < subBands; i++) {
			float startFrequency = i * (samplingRate / numSamples);
			float endFrequency = (i + subbandWidths[i]) * (samplingRate / numSamples);
			Debug.Log($"Subband {i + 1}: {startFrequency} Hz - {endFrequency} Hz");
		}
	}

	void Update() {
		//Get spectrum data
		spectrumSource.GetSpectrumData(spectrumData, 0, FFTWindow.Rectangular);

		//Divide FFT spectrum data into subbands
		int startIndex = 0;
		for (int i = 0; i < subBands; i++) {
			int endIndex = startIndex + (int)Mathf.Round(subbandWidths[i]);
			float sumOfSquares = 0.0f;
			for (int j = startIndex; j < endIndex; j++) {
				float value = spectrumData[j];
				sumOfSquares += (value * value);
			}
			Es[i] = sumOfSquares / (float)(endIndex - startIndex);
			startIndex = endIndex;
		}


		//Update energy history buffers and check for beats
		for (int i = 0; i < subBands; i++) {
			//Calculate average energy for subband [i]
			float sum = 0.0f;
			for (int j = 0; j < historySize; j++) {
				sum += Ei[i][j];
			}
			float avg = sum / (float)historySize;

			//Shift energy histroy buffer to the right
			for (int j = historySize - 1; j >= 1; j--) {
				Ei[i][j] = Ei[i][j - 1];
			}

			//Add new energy value to energy history buffer
			Ei[i][0] = Es[i];

			//check for beat
			if ((Es[i] > C * avg)) {
				subBandLogic[i] = true;
				samplesSinceLastBeat = 0;
			}
			if (Es[i] < C * avg) {
				subBandLogic[i] = false;
			}
		}

		samplesSinceLastBeat++;
		if (samplesSinceLastBeat > Mathf.RoundToInt(44100.0f / 40.0f)) {
			samplesSinceLastBeat = 0;
			Debug.Log("Beat ended");
		}
	}
}