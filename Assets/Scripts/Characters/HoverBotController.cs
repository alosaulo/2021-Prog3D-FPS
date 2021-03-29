using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBotController : Character
{
    public GameObject PrefabDeathBall;

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
            Vector3 posInit = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            Instantiate(PrefabDeathBall, posInit, Quaternion.identity);
            Death();
        }
    }

}
