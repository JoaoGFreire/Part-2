using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader2 : MonoBehaviour
{
    public void LoadScene()
    {
        int SceneCurrent = SceneManager.GetActiveScene().buildIndex;
        int SceneNext = (SceneCurrent + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(SceneNext);
    }
}
