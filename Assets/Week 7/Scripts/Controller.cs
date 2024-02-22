using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoccerPlayer selectedPlayer { get; private set; }
    public static void SetSelectedPlayer(SoccerPlayer player)
    {
        if(selectedPlayer != null)
        {
            selectedPlayer.Selected(false);
        }
        selectedPlayer = player;
        selectedPlayer.Selected(true);
    }
}
