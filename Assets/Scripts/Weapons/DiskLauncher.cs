using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskLauncher : Weapon
{

    public GameObject prefabDisk;
    public GameObject weaponDisk;

    public float projectileSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Shoot()
    {
        GameObject go = Instantiate(prefabDisk, weaponDisk.transform.position, Quaternion.identity);
        go.GetComponent<Rigidbody>().AddRelativeForce(Camera.main.transform.forward * projectileSpeed);
        weaponDisk.SetActive(false);
    }

}
