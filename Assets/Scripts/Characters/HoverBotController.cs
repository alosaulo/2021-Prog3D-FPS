using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBotController : EnemyBehaviour
{
    public float shotDistance;
    public float atkSpeed;
    bool isAttacking = false;
    public float atkDelay;
    float countAtk;


    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (countAtk < atkDelay && isAttacking == true)
        {
            countAtk += Time.deltaTime;
        }
        else if (countAtk > atkDelay) {
            countAtk = 0;
            isAttacking = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") {
            Vector3 newTarget = new Vector3(other.transform.position.x+0.3f,
                other.transform.position.y + 1,
                other.transform.position.z);
            target = other.transform;
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > shotDistance)
            {
                transform.LookAt(newTarget);
                FollowTarget();
            }
            else if(distance <= shotDistance){
                transform.LookAt(newTarget);
                if (isAttacking == false) { 
                    GameObject GO = Instantiate(atkPrefab, atkOrigin.position, atkOrigin.rotation);
                    EnemyShootController esc = GO.GetComponent<EnemyShootController>();
                    esc.SetStart(atkDamage, atkSpeed);
                    isAttacking = true;
                }
            }
        }
    }

}
