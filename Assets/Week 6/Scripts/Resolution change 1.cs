using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolutionchange1 : MonoBehaviour
{
    public int width;
    public int height;
    // Start is called before the first frame update
    public void SetWidth(int newWidth)
    {
        width = newWidth;
    }
    public void SetHeight(int newHeight)
    {
        width = newHeight;
    }
    public void setRes()
    {
        Screen.SetResolution(width, height, false);
    }
}
