using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public GameObject prefabProjectilePistol;
    public Transform originProjectile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckCooldown();
    }

    public override void Shoot()
    {
        if(canShoot == true) {
            RaycastHit ray;
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * maxRange, Color.cyan, 1f);
            
            bool hit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * maxRange, out ray, maxRange);
            
            GameObject GO = Instantiate(prefabProjectilePistol, originProjectile.position, originProjectile.rotation);
            GO.GetComponent<Projectile>().InitializeProjectile(ray);
            
            if (hit)
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
