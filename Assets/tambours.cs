using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tambours : MonoBehaviour {

	// Use this for initialization
	void Start () {

		
	}

    public float currentTime = 0.0f;

    void Update()
    {
        currentTime += Time.deltaTime;
        //Debug.Log(AudioSettings.dspTime);
    }
}
