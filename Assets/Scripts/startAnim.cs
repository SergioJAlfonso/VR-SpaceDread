using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnim : MonoBehaviour
{
    public GameObject monieco; //El monieco animao

    public void startAnimasiao()
    {
        monieco.GetComponent<Animator>().enabled = true;
    }
}
