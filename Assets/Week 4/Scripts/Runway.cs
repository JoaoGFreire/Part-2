using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public GameObject PlanePrefab;
    public AnimationCurve landingRunway;
    public float test;
    public float timer;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        test = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnOverlap(Collider2D collision)
    {
        timer += 0.5f * Time.deltaTime;
        float interpolation = landingRunway.Evaluate(timer);
        if (collision.transform.localScale.z < 0.1f)
        {
            Destroy(collision.gameObject);
        }
        collision.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero,interpolation);
        score++;
        
    }
}
