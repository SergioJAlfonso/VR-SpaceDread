using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 *   Simple Animation State Player
 *   Monchi Master
 */

public class ObjectAnim : MonoBehaviour
{
    [SerializeField]
    private Animator objectAnimator;
    [SerializeField]
    private string StateAnimationName;
    bool animationDirection = false;


    void Start()
    {
        if (objectAnimator == null)
            objectAnimator = GetComponent<Animator>();
        if (StateAnimationName == null)
            StateAnimationName = "";
    }

    //// OLD KEYBOARD INPUT
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //        PlayAnimation();
    //}

    public void PlayAnimation()
    {
        objectAnimator.Play(StateAnimationName);
        animationDirection = false;
    }

    public void PlayAnimationReversed()
    {
        objectAnimator.Play("Reversed" + StateAnimationName);
        animationDirection = true;
    }

    public void switchAnimation()
    {
        if (animationDirection)
            PlayAnimation();
        else
            PlayAnimationReversed();
    }
}
