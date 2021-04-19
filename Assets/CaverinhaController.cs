using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaverinhaController : EnemyBehaviour
{
    Transform target;

    float distanceFromTarget;

    // Start is called before the first frame update
    void Start()
    {
        target = GameManager._instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromTarget = Vector3.Distance(transform.position, target.position);
        transform.LookAt(target);
        if (distanceFromTarget >= 1.5)
        {
            rigidBody.MovePosition
                (Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime));
            myAnimator.SetBool("Walk", true);
        }
        else {
            myAnimator.SetBool("Walk", false);
        }
    }
}
