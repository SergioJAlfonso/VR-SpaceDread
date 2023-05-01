using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnim : MonoBehaviour
{
    public GameObject monieco; //El monieco animao
    public float finJuego; //El tiempo que queremos hasta que se cierre el juego
    float timer = 0.0f;
    bool ending = false;

    public void startAnimasiao()
    {
        monieco.GetComponent<Animator>().enabled = true;
        ending = true;
    }

    public void Update()
    {
        if (ending)
        {
            timer += Time.deltaTime;

            if (timer >= finJuego) Application.Quit();
        }
    }
}
