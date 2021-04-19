using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ammo
{
    public AmmoType ammoType;
    public float currentAmmo;
    public float maxAmmo;

    public void RecoverAmmo(int gain)
    {
        currentAmmo += gain;
        if (currentAmmo > maxAmmo)
            currentAmmo = maxAmmo;
    }

    public void LoseAmmo(int qnt)
    {
        if (currentAmmo > 0)
        {
            currentAmmo -= qnt;
        }
    }

}
