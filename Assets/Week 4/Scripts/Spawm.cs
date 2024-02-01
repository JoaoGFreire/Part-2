using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawm : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlanePrefab;
    public float time = 0f;
    public float timeTrigger = 5f;


    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > timeTrigger)
        {
            time = 0f;
            Instantiate(PlanePrefab,transform.position,transform.rotation);
        }
    }
}
