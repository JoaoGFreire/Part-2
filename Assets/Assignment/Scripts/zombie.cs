using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class zombie : MonoBehaviour
{
    Vector2 destination;
    Vector2 movement;
    public float speed = 5f;
    bool isDead;
    bool clickingOnSelf;
    bool ready2die;

    public float time = 0;
    public float timeTrigger = 5f;


    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        isDead = false;
        ready2die = false;
    }
    private void FixedUpdate()
    {
        if (isDead) return;

        movement = destination - (Vector2)(transform.position);
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        if (Input.GetMouseButtonDown(0) && !clickingOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        animator.SetFloat("Movement",movement.magnitude);

        time += Time.deltaTime;

        if (time > timeTrigger)
        {
   
            ready2die = true;
        }

    }
    private void OnMouseDown()
    {
        if (isDead) return;
        if (isDead) return;
        clickingOnSelf = true;
        SendMessage("TakeDamage");
    }
    private void OnMouseUp()
    {
        clickingOnSelf = false;
    }
    public void TakeDamage()
    {
        if (ready2die)
        {
            isDead = true;
            animator.SetTrigger("Dead");
        }
        else
        {
            animator.SetTrigger("Damage");
        }
    }
}
