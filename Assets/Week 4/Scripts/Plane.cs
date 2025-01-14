using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPositionThreshold = 0.2f;
    Vector2 lastPosition;
    Vector2 currentPosition;
    Rigidbody2D rb;
    public float speed = 1.0f;

    LineRenderer lineRenderer;

    public Sprite[] planes = new Sprite[4]; 


    public AnimationCurve landing;
    float landingTimer;

    SpriteRenderer spriteRenderer;

    public GameObject runway;

    private void Start()
    {
        float xposition = Random.Range(-5, 5);
        float yposition = Random.Range(-5, 5);
        Vector3 pos = new Vector3(xposition, yposition, 0);
        float zrotation = Random.Range(1, 3);

        transform.position = pos;
        transform.rotation = Quaternion.Euler(0, 0, zrotation);

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = planes[Random.Range(0,3)];

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0,transform.position);

        rb = GetComponent<Rigidbody2D>();

    }
   private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one,Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0])< newPositionThreshold) 
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }
    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(newPosition, lastPosition) > newPositionThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount -1, newPosition);
            lastPosition = newPosition;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != runway.gameObject)
        {
            spriteRenderer.color = Color.red;
        }
        //spriteRenderer.color = Color.red;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        float Dist = Vector3.Distance(transform.position,collision.transform.position);
        if (Dist < 0.5 && collision.gameObject != runway.gameObject)
        {
            Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
