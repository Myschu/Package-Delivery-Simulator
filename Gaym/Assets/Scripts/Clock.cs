using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {

    private const float REAL_SECONDS_PER_INGAME_DAY = 60f;

    private Transform ClockHandHourTransform;
    private Transform ClockHandMinTransform;
    private Text TimeText;
    private float day;

    private void Awake() {
        ClockHandHourTransform = transform.Find("ClockHandHour");
        ClockHandMinTransform = transform.Find("ClockHandMin");
        TimeText = transform.Find("TimeText").GetComponent<Text>();
    }

    private void Update() {
        day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

        float dayNormalized = day % 1f;

        float rotationDegreesPerDay = 360f;
        ClockHandHourTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay);

        float hoursPerDay = 24f;
        ClockHandMinTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreesPerDay * hoursPerDay);

        string hoursString = Mathf.Floor(dayNormalized * hoursPerDay).ToString("00");

        float minutesPerHour = 60f;
        string minutesString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * minutesPerHour).ToString("00");

        TimeText.text = hoursString + ":" + minutesString;
    }

}
