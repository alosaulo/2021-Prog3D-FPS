using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskProjectile : MonoBehaviour
{

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject go = Instantiate(explosion, transform.position, Quaternion.Euler(new Vector3(180,0,0)));
        Destroy(gameObject);
    }

}
