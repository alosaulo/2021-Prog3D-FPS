using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public int maxAmmo;
    public int maxCartridge;

    public int currentAmmo;
    public int cartridge;

    public float RateOfFire;

    float countRoF;
    protected bool canShoot;

    public void RecoverAmmo(int gain) {
        currentAmmo += gain;
        if (currentAmmo > maxAmmo)
            currentAmmo = maxAmmo;
    }

    public void RecoverCartridge(int gain)
    {
        cartridge += gain;
        if (cartridge > maxCartridge)
            cartridge = maxCartridge;
    }

    public void LoseAmmo(int qnt) { 
        if(currentAmmo > 0){
            currentAmmo -= qnt;
        }
    }

    public void LoseCartridge(int qtd) {
        if (cartridge > 0) {
            cartridge -= qtd;
        } else if (cartridge <= 0) {
            canShoot = false;
        }
    }

    public void Reload() {
        int qnt = currentAmmo - maxCartridge;
        if (qnt < 0 && currentAmmo > 0)
        {
            cartridge = currentAmmo;
            currentAmmo = 0;
        }
        else if(currentAmmo > 0) {
            cartridge = maxCartridge;
            currentAmmo -= maxCartridge;
        }
    }

    public virtual void Shoot(int qtd) {
        LoseCartridge(qtd);
        if (cartridge == 0) {
            Reload();
        } else if (cartridge <= 0 && currentAmmo <= 0) {
            canShoot = false;
        }
    }

    protected void CheckCooldown()
    {
        if (canShoot == false && cartridge > 0) {
            countRoF += Time.deltaTime;
            if (countRoF >= RateOfFire) { 
                canShoot = true;
            }
        }
    }

}
