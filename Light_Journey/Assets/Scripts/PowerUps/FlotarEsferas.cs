using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlotarEsferas : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
 
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(0f,0.5f,0f) *( Time.deltaTime * speed) * Mathf.Cos(Time.time));
    }
}
