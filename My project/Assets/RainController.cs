using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainController : MonoBehaviour
{
    // Reference to the Particle System (make sure this is public)
    public ParticleSystem rain;
    
    // Duration for which rain will fall
    public float rainDuration = 10f;
    
    // Time before rain starts again
    public float rainInterval = 20f;

    // Timer variables
    private float rainTimer;
    private bool isRaining;

    void Start()
    {
        // Start with rain
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
