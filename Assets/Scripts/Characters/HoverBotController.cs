using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBotController : Character
{
    public GameObject DeathParticle;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoDamage(float damage) {
        myAnimator.SetTrigger("hurt");
        myHealth.LoseHealth(damage);
        if (myHealth.currentHealth <= 0)
        {
            Instantiate(DeathParticle, transform.position, Quaternion.identity);
            Death();
        }
    }

}
