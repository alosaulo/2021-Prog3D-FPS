using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesBehavior : MonoBehaviour
{

    ParticleSystem PS;

    public float duration;
    float countDuration;

    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<ParticleSystem>();
        PS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        countDuration += Time.deltaTime;
        if (countDuration > duration) {
            PS.Stop();
            Destroy(gameObject, 1f);
        }
    }
}
