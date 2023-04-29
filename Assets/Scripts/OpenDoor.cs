using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool opening = false;

    public void open()
    {
        opening = true;
    }

    private void Update()
    {
        open();
        if (opening)
        {
            Debug.Log("Risuo");
            transform.Translate(new Vector3(0, 0.01f, 0));
        }
    }
}
