using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeNumber : MonoBehaviour
{
    public GameObject number;  //El objeto que tiene que cambiar de sprite
    public Sprite[] sprites;    //Los sprites pa que cambie

    public int currentNumber; //Para setearlo a cada boton

    public void onPress()
    {
        currentNumber++;

        if (currentNumber == 10) currentNumber = 0;

        number.GetComponent<SpriteRenderer>().sprite = sprites[currentNumber];
    }
}
