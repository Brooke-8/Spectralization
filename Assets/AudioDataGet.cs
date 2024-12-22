using UnityEngine;
using NAudio.Wave;
using System;

public class AudioDataGet : MonoBehaviour
{
    //Wave audio imput set up
    private WaveInEvent audioInput;
    public int deviceNumber = 1;
    private BufferedWaveProvider waveProvider;
    //Buffer set up
    private const int SAMPLE_RATE = 44100;
    private const int CHANNELS = 2;
    public int BUFFER_TIME = 3000;
    //Audio output set up
    private AudioClip audioClip;
    private AudioSource audioSource;
    //Timing
    private float startTime;
    private float elapsedTime;



    // Start is called before the first frame update
    void Awake()
    {
        startTime = Time.time;
        //Get audio from recording device
        audioInput = new WaveInEvent();
        audioInput.DeviceNumber = deviceNumber;
        audioInput.WaveFormat = new WaveFormat(SAMPLE_RATE, CHANNELS);
        waveProvider = new BufferedWaveProvider(audioInput.WaveFormat);
        waveProvider.BufferDuration = TimeSpan.FromMilliseconds(BUFFER_TIME);
        audioInput.DataAvailable += OnDataAvailable;
        
        audioClip = AudioClip.Create("AudioClip", SAMPLE_RATE * BUFFER_TIME, CHANNELS, SAMPLE_RATE, false);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;

        audioInput.BufferMilliseconds = BUFFER_TIME;
        audioInput.StartRecording();

    }

    void OnDataAvailable(object sender, WaveInEventArgs e)
    {

        //Debug.Log("(Spectrum) Recorded Bytes: " + e.BytesRecorded);
        //Debug.Log("(Spectrum) Buffer " + e.Buffer.Length);
        waveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
    }

    void Update()
    {
        // If there is audio data in the BufferedWaveProvider, copy it to the AudioClip and play it
        try
        {

            if (waveProvider.BufferedBytes > 0)
            {

                // Get the audio data from the BufferedWaveProvider
                byte[] audioData = new byte[waveProvider.BufferedBytes];
                waveProvider.Read(audioData, 0, audioData.Length);

                //Debug.Log("(Spectrum) AudioData: " + audioData.Length);

                // Convert the audio data to floats
                const float conversionFactor = 1f / short.MaxValue;
                float[] floatData = new float[audioData.Length / 2];

                for (int i = 0; i < floatData.Length; i++)
                {
                    floatData[i] = (float)BitConverter.ToInt16(audioData, i * 2) * conversionFactor;
                }

                audioClip.SetData(floatData, 0);
                audioSource.Play();
                elapsedTime = Time.time - startTime;
                //Debug.Log("Time: " + elapsedTime.ToString());

            }
            else
            {
                //Debug.LogWarning("Buffer Underflow");

            }

        }
        catch (Exception e)
        {
            Debug.LogWarning("(Spectrum) Failed to read audio data: " + e.Message);
        }

    }
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            // Paused, clear the buffers
            audioSource.Stop();
            waveProvider.ClearBuffer();
            audioClip.UnloadAudioData();
            startTime = Time.time;
        }
    }

    void OnApplicationQuit()
    {
        // Game is quitting, clear the buffers
        audioSource.Stop();
        waveProvider.ClearBuffer();
        audioClip.UnloadAudioData();
        startTime = Time.time;
    }

}
