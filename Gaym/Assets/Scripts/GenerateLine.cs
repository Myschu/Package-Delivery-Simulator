using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLine : MonoBehaviour
{

    public Transform[] points;

    // Start is called before the first frame update
    void Update()
    {
        LineRenderer line = new LineRenderer();

    

        line.SetPosition(0, points[0].position);
        line.SetPosition(1, points[1].position);




    }



}
