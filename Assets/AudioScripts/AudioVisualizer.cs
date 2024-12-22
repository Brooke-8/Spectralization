using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public AudioSource audioSource;
    public float sensitivity = 100.0f;
    public float smoothing = 0.1f;
    public int numSamples = 512;

    private float[] spectrumData;
    private float[] smoothedData;

    void Start()
    {
        spectrumData = new float[numSamples];
        smoothedData = new float[numSamples];
    }

    void Update()
    {
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
        

        for (int i = 0; i < numSamples; i++)
        {
            smoothedData[i] = Mathf.Lerp(smoothedData[i], spectrumData[i], smoothing);
        }

        for (int i = 0; i < numSamples; i++)
        {
            float intensity = smoothedData[i] * sensitivity;
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Lerp(scale.y, intensity, smoothing);
            transform.localScale = scale;
            
        }
    }
}