using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Ammo myAmmo;

    public float RateOfFire;

    float countRoF;

    protected bool canShoot;

    public virtual void Shoot(int qtd) {
        if (myAmmo.currentAmmo > 0) {
            myAmmo.LoseAmmo(qtd);
        }
        else if (myAmmo.currentAmmo <= 0) {
            canShoot = false;
        }
    }

    protected void CheckCooldown()
    {
        if (canShoot == false) {
            countRoF += Time.deltaTime;
            if (countRoF >= RateOfFire) { 
                canShoot = true;
            }
        }
    }

}
