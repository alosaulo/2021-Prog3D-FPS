using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager._instance.HUDManager.HUDPistol.SetAmmo(myAmmo.maxAmmo, myAmmo.currentAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCooldown();
    }

    public override void Shoot(int qtd)
    {
        if(canShoot == true) { 
            base.Shoot(qtd);
            GameManager._instance.HUDManager.HUDPistol.SetActualAmmo(myAmmo.currentAmmo);
            RaycastHit ray;
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward, Color.cyan, 10f);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out ray, 10f))
            {
                if (ray.collider.tag == "Enemy")
                {
                    EnemyBehaviour enemy = ray.collider.GetComponent<EnemyBehaviour>();
                    enemy.DoDamage(1);
                }
            }
        }
    }

}
