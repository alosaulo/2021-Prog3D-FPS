using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    Rigidbody myBody;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Destroy(gameObject);
    }

    public void InitializeProjectile(RaycastHit point) {
        myBody = GetComponent<Rigidbody>();
        myBody.AddRelativeForce(Vector3.forward * speed, ForceMode.Acceleration);
    }

}
