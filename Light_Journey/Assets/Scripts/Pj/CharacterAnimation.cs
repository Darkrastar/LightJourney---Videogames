using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animate;
    GameObject Player;
    Vida scriptVida;
    Character scriptCharacter;
    public CapsuleCollider col;
    public LayerMask groundLayers;

    void Start()
    {
        animate = this.GetComponent<Animator>();
        Player = GameObject.Find("Player");
        scriptVida = Player.GetComponent<Vida>();
        scriptCharacter = Player.GetComponent<Character>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
                        

           if (scriptCharacter.isJumping == true)
            {
                animate.SetInteger("EstadoPersonaje", 2);
            }
            else
            {
                animate.SetInteger("EstadoPersonaje", 1);
            }

        }

      else if (scriptCharacter.isJumping==true)
        {
            animate.SetInteger("EstadoPersonaje", 2);
          
        }

        else if (scriptVida.saludA <=0)
        {
            animate.SetInteger("EstadoPersonaje", 3);
            StartCoroutine(WaitAndDoSomething());
            
        }

        else
        {
            animate.SetInteger("EstadoPersonaje", 0);
        }

    }
    IEnumerator WaitAndDoSomething()
    {
        yield return new WaitForSeconds(3f);
        animate.gameObject.GetComponent<Animator>().enabled = false;
        // do something
    }
}
