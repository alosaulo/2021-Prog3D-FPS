using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public int maxAmmo;

    public int currentAmmo;


    public float RateOfFire;

    float countRoF;

    protected bool canShoot;

    public void RecoverAmmo(int gain) {
        currentAmmo += gain;
        if (currentAmmo > maxAmmo)
            currentAmmo = maxAmmo;
    }

    public void LoseAmmo(int qnt) { 
        if(currentAmmo > 0){
            currentAmmo -= qnt;
        }
    }

    public virtual void Shoot(int qtd) {
        if(currentAmmo > 0) { 
            LoseAmmo(qtd);
        }
        else if (currentAmmo <= 0) {
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
