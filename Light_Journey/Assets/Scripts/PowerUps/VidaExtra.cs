using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaExtra : MonoBehaviour
{

    public int regenera = 10;
    public ParticleSystem VidaRegenerada;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("F2");
        VidaRegenerada.Pause();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (other.CompareTag("Player") || other.tag == "Player")
        {
         
            other.GetComponent<Vida>().regenerar(regenera);
            gameObject.SetActive(false);
            VidaRegenerada.Play();
        }
        

        
    }
}
