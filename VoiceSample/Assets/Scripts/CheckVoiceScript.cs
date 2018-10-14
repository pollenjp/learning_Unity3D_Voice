using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckVoiceScript : MonoBehaviour {

    private AudioSource _aud;

	// Use this for initialization
	private void Start () {

        // ref: https://docs.unity3d.com/ScriptReference/Microphone-devices.html
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }


        // ref: https://docs.unity3d.com/ScriptReference/Microphone.Start.html
        string myMic = Microphone.devices[0];
        Debug.Log(myMic);

        _aud = GetComponent<AudioSource>();

        Debug.Log("Recoding!");
        _aud.clip = Microphone.Start(deviceName: myMic,
                                    loop: true,          // Enable recoding loop
                                    lengthSec: 100,      // Recoding time [sec]
                                    frequency: 44100);   // Sampling Frequency
        _aud.loop = true;                                 // Enable audio Loop

        while (!(Microphone.GetPosition(null) > 0)) { }  // Waiting for recognize Microphone Device

        Debug.Log("Play!");
        _aud.Play();

    }

    // Update is called once per frame
    private void Update () {
        float vol = GetAveragedVolume();
        Debug.Log("Volume: " + vol);
        Debug.Log("Microphone Position: " + Microphone.GetPosition(null));
    }

    private float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _aud.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256.0f;
    }

}
