using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{

    public Animator myAnimator;
    public Rigidbody rigidBody;

    public HealthController myHealth;

    public List<Weapon> myWeapons;
    public int actualWeapon;

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

}
