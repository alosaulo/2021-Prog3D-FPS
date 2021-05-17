using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public AmmoType ammoType;

    public float RateOfFire;

    public float maxRange;

    float countRoF;

    public bool canShoot;

    protected void CheckCooldown()
    {
        if (canShoot == false) {
            countRoF += Time.deltaTime;
            if (countRoF >= RateOfFire) { 
                canShoot = true;
            }
        }
    }

    public abstract void Shoot();

}
