using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{

    public int saludI = 100;
    public int saludA;
    public Slider barraV;

    private void Awake()
    {
        saludA = saludI;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void daño(int valorD)
    {
        saludA -= valorD;
        barraV.value = saludA;

     //   if (saludA <= 0) Destroy(gameObject);
    }

    public void regenerar(int valor)
    {
        saludA += valor;
        barraV.value = saludA;
    }

}
