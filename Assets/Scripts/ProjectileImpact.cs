using UnityEngine;
using System.Collections;

public class ProjectileImpact : MonoBehaviour
{
    ParticleSystem particle;

    // Use this for initialization
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        particle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (particle.isStopped)
        {
            Destroy(gameObject);
        }
    }
}
