using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool opening = false;

    float cuantity = 3.0f;

    float acumJeje = 0;

    public void open()
    {
        opening = true;
    }

    private void Update()
    {

        if (opening)
        {
            transform.Translate(new Vector3(0, 0.01f, 0));
            acumJeje += 0.01f;

            if (acumJeje >= cuantity) opening = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        open(); 
    }
}
