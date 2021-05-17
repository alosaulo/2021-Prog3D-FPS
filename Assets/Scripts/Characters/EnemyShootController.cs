using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    float speed;
    float damage;
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddRelativeForce(Vector3.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            player.DoDamage(damage);
        }
        if (other.gameObject.layer == 0) { 
            Destroy(gameObject);
        }
    }

    public void SetStart(float damage, float speed) {
        this.damage = damage;
        this.speed = speed;
    }

}
