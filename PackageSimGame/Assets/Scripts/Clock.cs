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

    public void Ticker(int minutes_passed) {
        /*
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

        if( hour % 12 == 0 )

        string hoursString = Mathf.Floor(hour%12).ToString("00");

        string minutesString = Mathf.Floor(min%60).ToString("00");

        TimeText.text = hoursString + ":" + minutesString;
        }
        public void Ticker(int extra)
         {
        if (extra == 0) { Ticker(); }
        else
        {*/
        Debug.Log("Called for : " + minutes_passed);

            string hoursString = "";
            string minutesString = "";

            //int minutes_passed = 0 + extra;
            float minutes_degrees = -6.0f * minutes_passed;
            float hours_degrees = -0.5f * minutes_passed;


            ClockHandHourTransform.Rotate(0, 0, hours_degrees, Space.Self);
            ClockHandMinTransform.Rotate(0, 0, minutes_degrees, Space.Self);

            min += minutes_passed;

            if (min >= 60)
            {
                hour++;
                min = min - 60;
            }

            if (hour%12 == 0)
            {
                hoursString = "12";
            }
            else
            {
                hoursString = Mathf.Floor(hour % 12).ToString("00");
            }

            minutesString = Mathf.Floor(min % 60).ToString("00");

            TimeText.text = hoursString + ":" + minutesString;

        


    }

}
