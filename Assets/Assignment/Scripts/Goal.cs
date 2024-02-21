using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public float test;
    public float timer;
    public AnimationCurve shrinking;
    void Start()
    {
        Vector3 position = new Vector3(0, -5, 0);
        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += 0.5f * Time.deltaTime;
        float interpolation = shrinking.Evaluate(timer);
        if(collision.transform.localScale.z < interpolation)
        {
            Destroy(collision.gameObject);
        }
        collision.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("its colliding");
        collision.gameObject.SendMessage("erase");
        //collision.gameObject.SendMessage("kill");
    }
}
