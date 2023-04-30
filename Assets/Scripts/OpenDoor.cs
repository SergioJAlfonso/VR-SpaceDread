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
        audioSource.Play();
    }

    public void close()
    {
        closing = true;
        audioSource.Play();
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) open();
        if (Input.GetKeyDown(KeyCode.C)) close();


        if (opening)
        {
            transform.Translate(new Vector3(0, 0.05f, 0));
            acumJeje += 0.05f;

            if (acumJeje >= cuantity) opening = false;
        }

        if (closing)
        {
            transform.Translate(new Vector3(0, -0.05f, 0));
            acumJejeBajar += 0.05f;

            if (acumJejeBajar >= cuantity) closing = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        open(); 
    }

    private void OnTriggerExit(Collider other)
    {
        close();
    }
}
