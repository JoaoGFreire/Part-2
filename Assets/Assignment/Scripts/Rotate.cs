using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject arrow;
    public float rspeed = 50f;
    bool rotateR = false;
    bool rotateL = false;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (rotateR)
        {
            arrow.transform.Rotate(0,0,  -rspeed * Time.deltaTime);
        }
        if (rotateL)
        {
            arrow.transform.Rotate(0,0,rspeed * Time.deltaTime);
        }
    }
    public void RotateRight()
    {
        rotateR = !rotateR;
        if (rotateL == true)
        {
            rotateL = false;
        }
    }
    public void RotateLeft()
    {
        rotateL = !rotateL;
        if (rotateR == true)
        {
            rotateR = false;
        }
    }
}
