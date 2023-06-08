using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum GameSelections { NONE, SHIELD, SPELL, SWORD}

public class GameplayController : MonoBehaviour
{
    [SerializeField] private Sprite shield_Sprint, spell_Sprite, sword_Sprite;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private Image playerSelection_Img, EnemySelection_Img;
    [SerializeField] private AudioClip tie_Sfx, swordWin_Sfx, swordLose_Sfx, shieldWin_Sfx, shieldLose_Sfx, spellWin_Sfx, spellLose_Sfx;

    //[SerializeField] private Text info_Text;

    private GameSelections player_Selection = GameSelections.NONE, enemy_Selection = GameSelections.NONE;

    private AnimationController animationController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }

    public void SetSelection(GameSelections gameSelection)
    {
        switch (gameSelection)
        {
            case GameSelections.SHIELD:
                playerSelection_Img.sprite = shield_Sprint;
                player_Selection = GameSelections.SHIELD;
                break;
            case GameSelections.SPELL:
                playerSelection_Img.sprite = spell_Sprite;
                player_Selection = GameSelections.SPELL;
                break;
            case GameSelections.SWORD:
                playerSelection_Img.sprite = sword_Sprite;
                player_Selection = GameSelections.SWORD;
                break;
        }

        SetEnemySelection();
         
        DetermineWinner();
    }

     void DetermineWinner()
    {
        if (player_Selection == enemy_Selection)
        {
            // Draw
            Debug.Log("Draw");
            audioSource.clip = tie_Sfx;
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if(player_Selection == GameSelections.SHIELD && enemy_Selection == GameSelections.SPELL)
        {
            //Lose
            Debug.Log("Sheild Lose");
            audioSource.clip = shieldLose_Sfx;
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SPELL && enemy_Selection == GameSelections.SWORD)
        {
            //Lose
            Debug.Log("Spell Lose");
            audioSource.clip = spellLose_Sfx;
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SWORD && enemy_Selection == GameSelections.SHIELD)
        {
            //Lose
            Debug.Log("Sword Lose");
            audioSource.clip = swordLose_Sfx;
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SHIELD && enemy_Selection == GameSelections.SWORD)
        {
            //Win
            Debug.Log("Shield Win");
            audioSource.clip = shieldWin_Sfx;
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SPELL && enemy_Selection == GameSelections.SHIELD)
        {
            //Win
            Debug.Log("Spell Win");
            audioSource.clip = spellWin_Sfx;
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SWORD && enemy_Selection == GameSelections.SPELL)
        {
            //Win
            Debug.Log("Sword Win");
            audioSource.clip = swordWin_Sfx;
            StartCoroutine(DetermineWinnerAndRestart());
        }  

    }

    IEnumerator DetermineWinnerAndRestart()
    {
        audioSource.Play();
        yield return new WaitForSeconds(2.0f);
        animationController.ResetAnimations();
    }

     void SetEnemySelection()
    {
        int rand = Random.Range(0, 2);

        switch (rand)
        {
            case 0:
                EnemySelection_Img.sprite = shield_Sprint;
                enemy_Selection = GameSelections.SHIELD;
                break;
            case 1:
                EnemySelection_Img.sprite = spell_Sprite;
                enemy_Selection = GameSelections.SPELL;
                break;
            case 2:
                EnemySelection_Img.sprite = sword_Sprite;
                enemy_Selection = GameSelections.SWORD;
                break;
        } 
    }
}
