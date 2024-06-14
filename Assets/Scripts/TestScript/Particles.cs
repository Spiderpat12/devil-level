using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    private ParticleSystem ps;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        // Check if particles are playing
        if (ps.isPlaying)
        {
            particles = new ParticleSystem.Particle[ps.particleCount];
            ps.GetParticles(particles);

            // Reverse particle velocity
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].velocity *= -1f;
                // You can also reverse other properties like size, rotation, etc.
            }

            // Apply modified particles back to system
            ps.SetParticles(particles, particles.Length);
        }
    }
}
