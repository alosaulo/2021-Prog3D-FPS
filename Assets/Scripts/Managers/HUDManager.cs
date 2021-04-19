using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    public HUDWeapon HUDPistol;
    public HUDWeapon HUDDisk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHUD(Ammo ammunition) {
        switch (ammunition.ammoType)
        {
            case AmmoType.Disk:
                HUDDisk.SetActualAmmo(ammunition.currentAmmo);
                break;
            case AmmoType.Bullet:
                HUDPistol.SetActualAmmo(ammunition.currentAmmo);
                break;
            default:
                break;
        }
    }

}
