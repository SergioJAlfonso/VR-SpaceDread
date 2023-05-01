using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class OpenDoor : MonoBehaviour
{
    bool opening = false;

    bool closing = false;

    float cuantity = 3.0f;

    float acumJeje = 0;

    float acumJejeBajar = 0;

    AudioSource audioSource;

    public void open()
    {
        opening = true;
        closing = false;
        audioSource.Play();
    }

    public void close()
    {
        closing = true;
        opening = false;
        audioSource.Play();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (opening)
        {
            transform.Translate(new Vector3(0, 0.01f, 0));
            acumJeje += 0.01f;

            //Cambiar este if si quereis que la animación empiece más arriba o más abajo
            if(acumJeje > (cuantity / 3)) //Para que la puerta final trigerre la animación del munieco
            {
                startAnim anim = GetComponent<startAnim>(); 

                if (anim != null) anim.startAnimasiao();
            }

            if (acumJeje >= cuantity)
            {
                opening = false;
                acumJeje = 0;
            }
        }

        if (closing)
        {
            transform.Translate(new Vector3(0, -0.01f, 0));
            acumJejeBajar += 0.01f;

            if (acumJejeBajar >= cuantity)
            {
                closing = false;
                acumJejeBajar = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(acumJejeBajar == 0 && acumJeje == 0) open();
    }

    private void OnTriggerExit(Collider other)
    {
        if (acumJejeBajar == 0 && acumJeje == 0) close();
    }
}
