using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentAtt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public Vector3 DefaultScale;


    private void Update()
    {
        Player.transform.localScale = DefaultScale;
    }

    private void OnTriggerEnter(Collider other)
    {

       
        if (other.gameObject == Player)
        {
            Debug.Log("touch");
          //  Player.transform.parent = transform;
           Player.transform.parent = transform;
        


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            //Player.transform.parent= null;
            Player.transform.parent= null;
              
        }
    }
}
