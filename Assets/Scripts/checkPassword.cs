using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPassword : MonoBehaviour
{
    public int[] contrase�a; // el primero es el primer numero desde la izquierda, y asi sucesivamente

    public GameObject[] buttons;

    public GameObject puerta;

    public void checkNumbers()
    {
        int i = 0;
        bool correcto = true;

        while (correcto)
        {
            int checkeo = buttons[i].GetComponent<changeNumber>().currentNumber;

            if (checkeo != contrase�a[i]) correcto = false;
            
            i++;
        }
    }

}
