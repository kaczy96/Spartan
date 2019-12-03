using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
    public Collider2D Collider;
    ParticleSystem GeyserParticleSystem;

    void Start()
    {
        GeyserParticleSystem = GetComponent<ParticleSystem>();
        StartCoroutine("Working");
    }

    public IEnumerator Working()
    {
        Collider.enabled = true;
        GeyserParticleSystem.Play();    
        yield return new WaitForSeconds(0.75f);
        Collider.enabled = false;
        StartCoroutine("NotWorking");
    }

    public IEnumerator NotWorking()
    {
        GeyserParticleSystem.Stop();
        yield return new WaitForSeconds(2f);
        StartCoroutine("Working");
    }
}


