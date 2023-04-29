using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool opening = false;

    bool closing = false;

    float cuantity = 3.0f;

    float acumJeje = 0;

    float acumJejeBajar = 0;

    public void open()
    {
        opening = true;
    }

    public void close()
    {
        closing = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) open();
        if (Input.GetKeyDown(KeyCode.C)) close();


        if (opening)
        {
            transform.Translate(new Vector3(0, 0.01f, 0));
            acumJeje += 0.01f;

            if (acumJeje >= cuantity) opening = false;
        }

        if (closing)
        {
            transform.Translate(new Vector3(0, -0.01f, 0));
            acumJejeBajar += 0.01f;

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
