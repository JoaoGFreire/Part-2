using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    Vector2 CurrentPos;
    Vector2 GoalPos;
    public GameObject goal;
    float eraseTime;

    public AnimationCurve erasing;


    // Start is called before the first frame update
    void Start()
    {
        float xposition = Random.Range(-5, 5);
        Vector3 position = new Vector3(xposition, 5, 0);
        transform.position = position;

        GoalPos = goal.transform.position;
        //transform.rotation = Quaternion.Euler(0, 0, 0);
        rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        CurrentPos = transform.position;
        Vector2 direction = GoalPos - CurrentPos;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        rb.rotation = -angle;
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void erase()
    {
        eraseTime -= 0.5f * Time.deltaTime;
        float interpolation = erasing.Evaluate(eraseTime);
        if(transform.localScale.z < interpolation)
        {
            Destroy(gameObject);
        }
        transform.localScale = Vector3.Lerp(Vector3.one,Vector3.zero,interpolation);
    }
    public void kill()
    {
        Destroy(gameObject);
    }
}
