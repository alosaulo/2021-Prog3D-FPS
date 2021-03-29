using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesExplosion : MonoBehaviour
{
    ParticleSystem PS;
    Collider collider;

    public float particleTime;
    public float destructionTime;
    public float damageTime;

    float countTimeParticle;
    float countTimeDestruction;
    float countDamage;

    // Start is called before the first frame update
    void Start()
    {
        PS = GetComponent<ParticleSystem>();
        PS.Play();
        collider = GetComponent<Collider>();
        countDamage = damageTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (countTimeParticle >= particleTime)
        {
            PS.Stop();
            collider.enabled = false;
            countTimeDestruction += Time.deltaTime;
            if (countTimeDestruction >= destructionTime)
            {
                Destroy(gameObject);
            }
        }
        else {
            countTimeParticle += Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        Character character = other.gameObject.GetComponent<Character>();
        if (character != null)
        {
            countDamage += Time.deltaTime;
            if(countDamage > damageTime) { 
                Debug.LogWarning("Entrei no character");
                character.DoDamage(1);
                countDamage = 0;
            }
        }
    }

}
