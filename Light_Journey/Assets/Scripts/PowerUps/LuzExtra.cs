using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzExtra : MonoBehaviour
{
    public float regenera = 10.0f;
    public LightChange script;
    public GameObject luz;
    public ParticleSystem LuzRegenerada;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("F2");
        luz = GameObject.Find("LightN");

        script = luz.GetComponent<LightChange>();
        LuzRegenerada.Pause();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Col3");
        if (other.CompareTag("Player") || other.tag == "Player")
        {
            script.LightEnergy += regenera;
            gameObject.SetActive(false);
            LuzRegenerada.Play();

        }
       
    }
}
