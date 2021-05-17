using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public float healthValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    public override void PickUp(PlayerController player)
    {
        if (!player.myHealth.isHealthFull()) { 
            player.myHealth.GainHealth(healthValue);
            Destroy(gameObject);
        }
    }

}
