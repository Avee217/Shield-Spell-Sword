using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    private AnimationController animationController;
    private GameplayController gameplayController;

    private string playerSelection;
    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
        gameplayController = GetComponent<GameplayController>();
    }

    public void getSelection()
    {
        string selection = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        GameSelections chosenSelection = GameSelections.NONE;

        switch (selection)
        {
            case "Shield":
                chosenSelection = GameSelections.SHIELD;
                break;
            case "Spell":
                chosenSelection = GameSelections.SPELL;
                break;
            case "Sword":
                chosenSelection = GameSelections.SWORD;
                break;
        }
        gameplayController.SetSelection(chosenSelection);
        animationController.PlayerSelection();
    }
}
