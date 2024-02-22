using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthB : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider health;
    public void TakeDamage(float value)
    {
        health.value -= value;
    }

    // Update is called once per frame
    void setHP(float value)
    {
        health.value = value;
    }
    public void updateHP(float value)
    {
        health.value = value;
    }
}
