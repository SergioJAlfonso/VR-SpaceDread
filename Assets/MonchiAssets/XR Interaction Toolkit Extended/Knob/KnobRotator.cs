using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class KnobRotator : MonoBehaviour
{
    [SerializeField] Transform knobObject;
    [SerializeField] private int snapRotationAmount = 25;
    [SerializeField] private float angleTolerance;
    [SerializeField] private bool shouldUseDummyHands;

    //Actual value of angle
    float actualAngle = 0;
    float angleCheck;

    [SerializeField] bool gotLimits;
    [SerializeField] private int higgerTop;
    [SerializeField] private int lowerTop;

    private XRBaseInteractor interactor;
    private float startAngle = 0;
    private bool requiresStartAngle = true;
    private bool shouldGetHandRotation = false;

    public UnityEvent raiseEvent;
    public UnityEvent lowerEvent;

    private XRGrabInteractable grabInteractable => GetComponent<XRGrabInteractable>();

    private void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(GrabbedBy);
        grabInteractable.selectExited.AddListener(GrabEnd);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(GrabbedBy);
        grabInteractable.selectExited.RemoveListener(GrabEnd);
    }

    private void GrabbedBy(SelectEnterEventArgs arg)
    {
        interactor = (XRBaseInteractor)arg.interactorObject;
        shouldGetHandRotation = true;
        startAngle = 0.0f;
    }

    private void GrabEnd(SelectExitEventArgs arg)
    {
        shouldGetHandRotation = false;
        requiresStartAngle = true;
    }

    private void Update()
    {
        //Debug.Log(actualAngle);

        if (shouldGetHandRotation)
        {
            var rotationAngle = GetInteractorRotation();
            GetRotationDistance(rotationAngle);
        }
    }

    public float GetInteractorRotation()
    {
        return interactor.GetComponent<Transform>().eulerAngles.z;
    }

    private void GetRotationDistance(float currentAngle)
    {
        if (!requiresStartAngle)
        {
            var angleDifference = Mathf.Abs(startAngle - currentAngle);

            if (angleDifference > angleTolerance)
            {
                if (angleDifference > 270f)
                {
                    if (startAngle < currentAngle)
                    {
                        angleCheck = CheckAngle(currentAngle, startAngle);

                        if (angleCheck < angleTolerance)
                            return;
                        else
                        {
                            if (RotateDialClockWise())
                                actualAngle += snapRotationAmount;
                            startAngle = currentAngle;
                        }
                    }
                    else if (startAngle > currentAngle)
                    {
                        angleCheck = CheckAngle(currentAngle, startAngle);

                        if (angleCheck < angleTolerance)
                            return;
                        else
                        {
                            if (RotateDialAntiClockWise())
                                actualAngle -= snapRotationAmount;
                            startAngle = currentAngle;
                        }
                    }
                }
                else
                {
                    if (startAngle < currentAngle)
                    {
                        if (RotateDialAntiClockWise())
                            actualAngle -= snapRotationAmount;
                        startAngle = currentAngle;
                    }
                    else if (startAngle > currentAngle)
                    {
                        if (RotateDialClockWise())
                            actualAngle += snapRotationAmount;
                        startAngle = currentAngle;
                    }
                }
            }
        }
        else
        {
            requiresStartAngle = false;
            startAngle = currentAngle;
        }
    }

    private float CheckAngle(float currentAngle, float startAngle) => (360f - currentAngle) + startAngle;

    private bool RotateDialClockWise()
    {
        if (gotLimits)
        {
            if (actualAngle < higgerTop)
            {
                knobObject.localEulerAngles = new Vector3(knobObject.localEulerAngles.x, knobObject.localEulerAngles.y, knobObject.localEulerAngles.z + snapRotationAmount);
                if (raiseEvent != null)
                    raiseEvent.Invoke();
                return true;
            }
        }
        else
        {
            knobObject.localEulerAngles = new Vector3(knobObject.localEulerAngles.x, knobObject.localEulerAngles.y, knobObject.localEulerAngles.z + snapRotationAmount);
            if (raiseEvent != null)
                raiseEvent.Invoke();
            return true;
        }

        return false;
    }

    private bool RotateDialAntiClockWise()
    {
        if (gotLimits)
        {
            if (actualAngle > lowerTop)
            {
                knobObject.localEulerAngles = new Vector3(knobObject.localEulerAngles.x, knobObject.localEulerAngles.y, knobObject.localEulerAngles.z - snapRotationAmount);
                if (lowerEvent != null)
                    lowerEvent.Invoke();
                return true;
            }
        }
        else
        {
            knobObject.localEulerAngles = new Vector3(knobObject.localEulerAngles.x, knobObject.localEulerAngles.y, knobObject.localEulerAngles.z - snapRotationAmount);
            if (lowerEvent != null)
                lowerEvent.Invoke();
            return true;
        }
        return false;
    }
}
