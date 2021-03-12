using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    // Start is called before the first frame update
    public Animator animate;
    public GameObject Enemy;
    EnemyAi scriptEnemigo;
      public CapsuleCollider col;
    

    void Start()
    {
        animate = this.GetComponent<Animator>();
        //Enemy = GameObject.Find("Enemy");
        scriptEnemigo = Enemy.GetComponent<EnemyAi>();
        
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scriptEnemigo.EstadoPersonaje == 0)
        {
            animate.SetInteger("EstadoPersonaje", 0);
        }
        else
        {
            animate.SetInteger("EstadoPersonaje", 1);
        }

    }
}
