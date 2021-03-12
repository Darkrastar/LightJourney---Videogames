using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine.PostFX;

public class LightChange : MonoBehaviour
{
    // Start is called before the first frame update
    public Light myLight;
    public bool status;
    public float LightEnergy;
    public int energiaI;
    public Slider barraL;
    public int laLuz;

    public CinemachinePostProcessing pp;
    Vignette filtroVignette =null;

    public GameObject player;
    
    

    void Start()
    {  
        myLight =GetComponent<Light>();
        myLight.intensity=0.0f;
        status = false;
        LightEnergy = 200.0f;

         pp.m_Profile.TryGetSettings(out filtroVignette);
         filtroVignette.intensity.value = 0.8f ; 
        



    }

    public void actualizar()
    {
        
        barraL.value = energiaI;


    }

    // Update is called once per frame
    void Update()
    {

            energiaI = (int)LightEnergy;




        if (Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(1))
        {



            LightEnergy = LightEnergy - 5.0f * Time.deltaTime;
            if (myLight.intensity <=8.0)
            {
               
                status = true;
                myLight.intensity += 20.0f * Time.deltaTime;

               

            }
            if (LightEnergy <= 0.0f)
            {
                status = false;
                LightEnergy = 0.0f;
                myLight.intensity = 0.0f;
                filtroVignette.intensity.value = Mathf.Lerp(filtroVignette.intensity.value, 0.8f, 10f * Time.deltaTime);
                player.GetComponent<Vida>().daño(100);
            }
            else
            {
                filtroVignette.intensity.value = Mathf.Lerp(filtroVignette.intensity.value, 0.5f, 10f * Time.deltaTime);
            }


            actualizar();
          
            print(LightEnergy);



        }

        else
        {
           
           status = false;
           myLight.intensity -= 20.0f * Time.deltaTime;
            filtroVignette.intensity.value = Mathf.Lerp(filtroVignette.intensity.value, 0.8f, 10f * Time.deltaTime);
            actualizar();
        }

        
     
       
    }



}
