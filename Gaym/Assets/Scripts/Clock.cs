using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

    private const float REAL_SECONDS_PER_INGAME_DAY = 60f;

    private Transform ClockHandHourTransform;
    private Transform ClockHandMinTransform;
    private Text TimeText;
    public float hour = 8;
    public float min = 0;
    //float timeToGo;

    private void Awake() {
        ClockHandHourTransform = transform.Find("ClockHandHour");
        ClockHandMinTransform = transform.Find("ClockHandMin");
        TimeText = transform.Find("TimeText").GetComponent<Text>();
        ClockHandHourTransform.Rotate(0, 0, 120, Space.Self);

    }

    public void Ticker() {

        //ClockHandHourTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);
        //ClockHandHourTransform.RotateAround(new Vector3(-322.0f, 114.0f, 0.0f), Vector3.forward, 180*Time.deltaTime);
        ClockHandHourTransform.Rotate(0, 0, -15, Space.Self);

        //ClockHandMinTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);
        //ClockHandMinTransform.RotateAround(new Vector3(-322.0f, 114.0f, 0.0f), Vector3.forward, 15* Time.deltaTime);
        ClockHandMinTransform.Rotate(0, 0, -180, Space.Self);

        min += 30;

        if (min == 60)
        {
            min = 0;
            hour += 1;
        }

        string hoursString = Mathf.Floor(hour%12).ToString("00");

        string minutesString = Mathf.Floor(min%60).ToString("00");

        TimeText.text = hoursString + ":" + minutesString;
    }

}
