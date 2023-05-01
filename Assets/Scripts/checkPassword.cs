using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPassword : MonoBehaviour
{
    public int[] contrase�a; // el primero es el primer numero desde la izquierda, y asi sucesivamente

    public GameObject[] buttons;

    public void checkNumbers()
    {
        int i = 0;
        bool correcto = true;

        while ( i < buttons.Length && correcto)
        {
            int checkeo = buttons[i].GetComponent<changeNumber>().currentNumber;

            if (checkeo != contrase�a[i]) correcto = false;
            
            i++;
        }

        if(i == buttons.Length)
        {
            GetComponent<OpenDoor>().open();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) checkNumbers();
    }

}
