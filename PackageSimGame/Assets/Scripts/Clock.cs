using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Clock
 * 
 * Handles calculation for the clock in Truck_pathing scene
 * Manages start and end time and the display of any changes in time
 * 
 */

public class Clock : MonoBehaviour {

    private const float REAL_SECONDS_PER_INGAME_DAY = 60f;

    private Transform ClockHandHourTransform;
    private Transform ClockHandMinTransform;
    private Text TimeText;
    public float hour = 8;
    public float min = 0;

    private void Awake() {
        ClockHandHourTransform = transform.Find("ClockHandHour");
        ClockHandMinTransform = transform.Find("ClockHandMin");
        TimeText = transform.Find("TimeText").GetComponent<Text>();
        ClockHandHourTransform.Rotate(0, 0, 120, Space.Self);

    }

    /*
     * Callable function that updates the displayed time of the clock in the Truck_pathing scene
     * Calculates the angle of clock hands shown and analog time 
     */
    public void Ticker(int minutes_passed) {
        
        Debug.Log("Called for : " + minutes_passed);

            string hoursString = "";
            string minutesString = "";
        
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
