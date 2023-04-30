using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class changeNumber : MonoBehaviour
{
    public int currentNumber; //Para setearlo a cada boton

    public void onPress()
    {
        currentNumber++;

        if (currentNumber == 10) currentNumber = 0;

        GetComponent<TextMeshPro>().text = currentNumber.ToString();
    }

}
