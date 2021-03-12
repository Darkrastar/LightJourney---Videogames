using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine.PostFX;


public class DañoEnemigo : MonoBehaviour
{

    public int dañoE = 10;
     public CinemachinePostProcessing pp;

    Vignette filtroVignette = null;
    ColorGrading cg = null;
    void Start()
    {
      
       
      pp.m_Profile.TryGetSettings(out filtroVignette);
        pp.m_Profile.TryGetSettings(out cg);
        
        cg.colorFilter.value = new Color(1f, 1f, 1f, 0f);


    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Col");
        if (other.CompareTag("Player") || other.tag.Equals("Player"))

        {
            filtroVignette.intensity.value = Mathf.Lerp(filtroVignette.intensity.value, 1f, 10f * Time.deltaTime);
            cg.colorFilter.value = Color.Lerp(cg.colorFilter.value, new Color(0.1f,0.1f, 0.1f,0f), 10f* Time.deltaTime);
             StartCoroutine(waitAndDoSomething());
           

            other.GetComponent<Vida>().daño(dañoE);
             
          


        }
        
    }
    IEnumerator waitAndDoSomething()
    {
       yield return new WaitForSeconds(2f);
        filtroVignette.intensity.value = Mathf.Lerp(filtroVignette.intensity.value, 0.8f, 10f * Time.deltaTime);

        cg.colorFilter.value = Color.Lerp(cg.colorFilter.value, new Color(1f, 1f, 1f, 0f), 10f * Time.deltaTime);
    }
    
        
    


}
