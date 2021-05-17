using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : Pickup
{

    public AmmoType ammoType;
    public int qtd;

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
        int index = player.myAmmunitions.FindIndex(x => x.ammoType == ammoType);
        if (!player.myAmmunitions[index].isAmmoFull()) { 
            player.myAmmunitions[index].RecoverAmmo(qtd);
            Destroy(gameObject);
        }
    }

}
