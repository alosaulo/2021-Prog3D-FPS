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
        //Calcula a distância entre a caverinha e o alvo
        distanceFromTarget = Vector3.Distance(transform.position, target.position);
        //Verifica se é para executar uma animação com delay
        if(isDelaying == false) {
            //Olha pro alvo
            transform.LookAt(target);
            //Segue o personagem até se a distância for menor que 1.5
            if (distanceFromTarget >= 1.5 )
            {
                //Move atrás do player
                rigidBody.MovePosition
                    (Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime));
                //Ativa a animação de walk
                myAnimator.SetBool("Walk", true);
            }
            else{
                //Desativa a animação de walk
                myAnimator.SetBool("Walk", false);
                myAnimator.SetTrigger("Atk");
            }
        }
    }
}
