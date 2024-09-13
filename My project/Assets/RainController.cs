using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    public ParticleSystem rain;

    public float rainDuration = 10f;
    
    public float rainInterval = 20f;

    private float rainTimer;
    private bool isRaining;

    void Start()
    {
        rainTimer = rainDuration;
        isRaining = true;
        rain.Play();
    }

    void Update()
    {
        rainTimer -= Time.deltaTime;

        if (isRaining && rainTimer <= 0)
        {
            rain.Stop();
            isRaining = false;
            rainTimer = rainInterval;
        }
        else if (!isRaining && rainTimer <= 0)
        {
            rain.Play();
            isRaining = true;
            rainTimer = rainDuration;
        }
    }
}
