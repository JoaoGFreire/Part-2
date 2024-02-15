using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float speed = 3f;

    Rigidbody2D rb;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {
        Vector2 force = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        rb.AddForce(force);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
