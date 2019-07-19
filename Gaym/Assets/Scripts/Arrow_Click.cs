using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Click: MonoBehaviour
{


    public void OnClicked()
    {

        Static_Button_Info.setInfo(this.name);
        Debug.Log(Static_Button_Info.Down);

    }
}
