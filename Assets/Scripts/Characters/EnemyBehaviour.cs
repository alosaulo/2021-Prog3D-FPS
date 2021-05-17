using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : Character
{
    Vector3 startPosition;
    protected Transform target;


    [Header("Death Prefab")]
    public GameObject PrefabDeathBall;

    [Header("Animation Delay")]
    public float damageDelay;
    public float attackDelay;

    [Header("Attack Settings")]
    public GameObject atkPrefab;
    public Transform atkOrigin;
    public float atkRange;
    public float atkDamage;

    protected bool isDelaying = false;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void FollowTarget() {
        rigidBody.MovePosition(Vector3.MoveTowards(transform.position,target.position,speed * Time.deltaTime));
    }

    public override void DoDamage(float damage)
    {
        myAnimator.SetTrigger("hurt");
        myHealth.LoseHealth(damage);
        if (myHealth.currentHealth <= 0)
        {
            Vector3 posInit = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            GameObject dropItem = GameManager._instance.dropPickup.DropPrefab();
            Instantiate(dropItem, posInit, Quaternion.identity);
            Instantiate(PrefabDeathBall, posInit, Quaternion.identity);
            Death();
        }
    }

    /// <summary>
    /// Método para gerar delay nas animações
    /// </summary>
    /// <param name="delayTime">tempo de delay</param>
    public void StartDelay(float delayTime) {
        StartCoroutine("Delay", delayTime);
    }

    /// <summary>
    /// Método para gerar delay na animação de dano
    /// </summary>
    /// <param name="delayTime">tempo de delay</param>
    public void StartDelayDamage()
    {
        StartCoroutine("Delay", damageDelay);
    }

    /// <summary>
    /// Método para gerar delay na animação de ataque
    /// </summary>
    /// <param name="delayTime">tempo de delay</param>
    public void StartDelayAttack()
    {
        StartCoroutine("Delay", attackDelay);
    }

    IEnumerator Delay(float delayTime) {
        isDelaying = true;
        yield return new WaitForSeconds(delayTime);
        isDelaying = false;
    }

    public void AttackRayCast() {
        RaycastHit ray;
        Debug.DrawRay(atkOrigin.position, atkOrigin.transform.forward * atkRange, Color.red, 1);
        if (Physics.Raycast(atkOrigin.position, atkOrigin.transform.forward * atkRange, out ray, atkRange))
        {
            Debug.LogWarning(ray.collider.name);
            if (ray.collider.tag == "Player")
            {
                PlayerController player = ray.collider.GetComponent<PlayerController>();
                player.DoDamage(atkDamage);
            }
        }
    }

    public void AttackRanged() { 
        
    }

}
