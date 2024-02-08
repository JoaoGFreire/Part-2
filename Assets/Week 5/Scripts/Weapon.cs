using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 weaponMove;
    float time = 0f;
    float timeTrigger = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weaponMove = new Vector2(-2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timeTrigger)
        {
            time = 0f;
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + weaponMove * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

}
