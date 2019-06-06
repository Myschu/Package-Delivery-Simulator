using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeState : MonoBehaviour
{
    public GameObject[] buttons;

    public void Toggle()
    {
        int n = 0;
        while (buttons[n] != null)
        {
            bool isActive = buttons[n].activeSelf;

            buttons[n].SetActive(!isActive);
            n++;
        }
    }

}