using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBehaviour : MonoBehaviour {

    public Transform hoursTransform, minutesTranform,secondsTransform;
    public bool continuous = false;
    private const float _degreesPerHour = 30f;
    private const float _degreesPerMin = 6f;
    private const float _degreesPerSec = 6f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }
    }

    private void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * _degreesPerHour, 0f);
        minutesTranform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * _degreesPerMin, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * _degreesPerSec, 0f);
    }

    private void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation = Quaternion.Euler(0f, time.Hour * _degreesPerHour, 0f);
        minutesTranform.localRotation = Quaternion.Euler(0f, time.Minute * _degreesPerMin, 0f);
        secondsTransform.localRotation = Quaternion.Euler(0f, time.Second * _degreesPerSec, 0f);
    }

}
