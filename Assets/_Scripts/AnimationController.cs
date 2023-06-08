using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    [SerializeField] private Animator playerSelectionHandlerAnimation, selectionAnimatoion;

    public void ResetAnimations()
    {
        playerSelectionHandlerAnimation.Play("ShowPlayerHandler");
        selectionAnimatoion.Play("RemoveSelections");
    }

    public void PlayerSelection()
    {
        playerSelectionHandlerAnimation.Play("RemovePlayerHandler");
        selectionAnimatoion.Play("ShowSelections");
    }

}//class
