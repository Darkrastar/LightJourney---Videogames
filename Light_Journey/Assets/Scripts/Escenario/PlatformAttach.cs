using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{

    public GameObject player;
    public GameObject platform;
   
    bool activo = false;
    private void OnTriggerEnter(Collider other)
    {
    if(other.gameObject.CompareTag("Platform"))
        {
            print("Col");
            activo = true;
          // transform.parent.rotation= other.gameObject.transform.rotation;
            
           



        }

    }
    void Start()
    {
      
    }
    void Update()
    {
       
        if (activo == true)
        {

          
            player.transform.position += (platform.transform.right * 50f);
          
        }
        else
        {
            transform.parent = null;
        }
     
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
           // transform.parent = null;
            activo = false;
            print("descol");
        }

    }

}
