using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Simple Trigger Activation Tool to make effect on CallOnTriggerEfector Script
 *  Monchi Master
 */

public class CallOnTriggerTool : MonoBehaviour
{
    [SerializeField] Collider ToolColliderNeeded;
    [SerializeField] float deactivateTimer;
    private float actualTime = 0;
    bool activated = false;

    void Start()
    {
        ToolColliderNeeded = GetComponent<Collider>();
        ToolColliderNeeded.enabled = false;
    }
    public void Update()
    {
        if (ToolColliderNeeded != null && activated)
        {
            actualTime += Time.deltaTime;
            if (actualTime > deactivateTimer)
            {
                deactivateTool();
                actualTime = 0;
            }
        }
    }

    public void activateTool()
    {
        if (ToolColliderNeeded == null)
            Debug.Log("ToolWithout Collider");

        deactivateTool();                       //Desactivamos la anterior si existia
        ToolColliderNeeded.enabled = true;      //Activamos el collider
        activated = true;
        actualTime = 0;                         //Reinicia el Timer de despawn
    }

    public void deactivateTool()
    {
        if (ToolColliderNeeded == null)
            Debug.Log("ToolWithout Collider");
        ToolColliderNeeded.enabled = false;
        activated = false;
    }
}
