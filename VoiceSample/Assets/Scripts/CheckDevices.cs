using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDevices : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // ref: https://docs.unity3d.com/ScriptReference/Microphone-devices.html
        foreach (string device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
