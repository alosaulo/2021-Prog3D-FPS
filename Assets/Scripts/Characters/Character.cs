using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    public Animator myAnimator;
    public Rigidbody rigidBody;

    public HealthController myHealth;

    public List<Ammo> myAmmunitions;
    public List<Weapon> myWeapons;
    public int actualWeapon;
    public int ammoIndex;

    [Header("Física")]
    public float speed;

    // Start is called before the first frame update
    protected void Start()
    {
        myAnimator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    public void EnableWeapon() {

        for (int i = 0; i < myWeapons.Count; i++)
        {
            if (i != actualWeapon)
            {
                myWeapons[i].gameObject.SetActive(false);
            }
            else {
                myWeapons[i].gameObject.SetActive(true);
            }
        }
    }
    public virtual void DoDamage(float damage)
    {
        if (myHealth.currentHealth <= 0) { 
            Death();
        }
    }

    public void Death() {
        Destroy(gameObject);
    }

    public Weapon GetWeapon() {
        return myWeapons[actualWeapon];
    }

    public virtual void ShootWeapon(int qtd)
    {
        AmmoType ammoType = GetWeapon().ammoType;

        ammoIndex = myAmmunitions.FindIndex(x => x.ammoType == ammoType);

        if (myAmmunitions[ammoIndex].currentAmmo > 0)
        {
            GetWeapon().Shoot();
            myAmmunitions[ammoIndex].LoseAmmo(qtd);
        }
        else if (myAmmunitions[ammoIndex].currentAmmo <= 0)
        {
             GetWeapon().canShoot = false;
        }
    }

}
