using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public GameObject prefabPickup;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }

    public abstract void PickUp(PlayerController player);

}
