using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRobot : MonoBehaviour
{
    public GameObject RobotPF;
    public GameObject goal;
    public float time = 0f;
    public float timeTrigger = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(goal, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > timeTrigger)
        {
            time = 0f;
            Instantiate(RobotPF, transform.position, transform.rotation);
        }
    }
}
