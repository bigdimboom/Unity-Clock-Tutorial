using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    const float secondsToDegree = -1.0f / 60.0f * 360.0f;
    const float minutesToDegree = -1.0f / 60.0f * 360.0f;
    const float hoursToDegree = -30.0f;

    [SerializeField]
    Transform hoursPivot = default, minutesPivot = default, secondsPivot = default;

    [SerializeField]
    bool isContinous = default;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        SetArms(isContinous);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetArms(isContinous);
    }

    void SetArms(bool isContinous)
    {
        if(!isContinous)
        {
            var time = DateTime.Now;
            hoursPivot.localRotation = Quaternion.Euler(0, 0, time.Hour * hoursToDegree);
            minutesPivot.localRotation = Quaternion.Euler(0, 0, time.Minute * minutesToDegree);
            secondsPivot.localRotation = Quaternion.Euler(0, 0, time.Second * secondsToDegree);
            return;
        }

        var timeSpan = DateTime.Now.TimeOfDay;
        hoursPivot.localRotation = Quaternion.Euler(0, 0, (float)timeSpan.TotalHours * hoursToDegree);
        minutesPivot.localRotation = Quaternion.Euler(0, 0, (float)timeSpan.TotalMinutes * minutesToDegree);
        secondsPivot.localRotation = Quaternion.Euler(0, 0, (float)timeSpan.TotalSeconds * secondsToDegree);
    }

    public void ChangeMode()
    {
        isContinous = !isContinous;
    }
}
