using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private bool moving;
    public Vector3 velocity;
    public Vector3 velocityinverted;
    private int cheche = 1;
    public float left;
    public float right;
    public GameObject Player;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == Player)
        {
            moving = true;
            //collision.collider.transform.SetParent(transform);
            Player.transform.parent = transform;

        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == Player)
        {

            //collision.collider.transform.SetParent(null);
            Player.transform.parent = null;
            // moving = false;
        }
    }
    /*
    private void FixedUpdate()
    {

        print(transform.position);
        if (transform.position.z >= left && cheche == 1)
        {
            transform.position += (velocity * Time.deltaTime);

        }

        if (transform.position.z < left && cheche == 1)
        {
            cheche = 2;

        }

        if (transform.position.z <= right && cheche == 2)
        {
            transform.position += (velocityinverted * Time.deltaTime);
        }

        if (transform.position.z > right)
        {
            cheche = 1;
        }




    }*/

}
