using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    bool clickOnSelf;
    SpriteRenderer sr;
    public Color unselectedColor;
    public Color selectedColor;
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        //clickOnSelf = false;
        Selected(false);

    }

    // Update i
    private void OnMouseDown()
    {
        //clickOnSelf = true;
        Controller.SetSelectedPlayer(this);
    }
    public void Selected(bool clickOnSelf)
    {
        if (clickOnSelf)
        {
            sr.color = selectedColor;
        }
        else { sr.color = unselectedColor; }
    }
}
