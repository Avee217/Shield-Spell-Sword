using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Random = UnityEngine.Random;

public enum GameSelections { NONE, SHIELD, SPELL, SWORD}

public class GameplayController : MonoBehaviour
{
    [SerializeField] private Sprite shield_Sprint, spell_Sprite, sword_Sprite;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private RawImage screenUI;

    [SerializeField] private Image playerSelection_Img, EnemySelection_Img;
    [SerializeField] private AudioClip tie_Sfx, swordWin_Sfx, swordLose_Sfx, shieldWin_Sfx, shieldLose_Sfx, spellWin_Sfx, spellLose_Sfx;

    [SerializeField] List<EnemyData> enemies = new List<EnemyData>();


    private EnemyData currentEnemy;

    //[SerializeField] private Text info_Text;

    private GameSelections player_Selection = GameSelections.NONE, enemy_Selection = GameSelections.NONE;

    private AnimationController animationController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
        currentEnemy = enemies[0];
        screenUI.enabled = false;
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
            videoPlayer.clip = currentEnemy.Videos[0];
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if(player_Selection == GameSelections.SHIELD && enemy_Selection == GameSelections.SPELL)
        {
            //Lose
            Debug.Log("Sheild Lose");
            audioSource.clip = shieldLose_Sfx;
            videoPlayer.clip = currentEnemy.Videos[1];
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SPELL && enemy_Selection == GameSelections.SWORD)
        {
            //Lose
            Debug.Log("Spell Lose");
            audioSource.clip = spellLose_Sfx;
            videoPlayer.clip = currentEnemy.Videos[1];
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SWORD && enemy_Selection == GameSelections.SHIELD)
        {
            //Lose
            Debug.Log("Sword Lose");
            audioSource.clip = swordLose_Sfx;
            videoPlayer.clip = currentEnemy.Videos[1];
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SHIELD && enemy_Selection == GameSelections.SWORD)
        {
            //Win
            Debug.Log("Shield Win");
            audioSource.clip = shieldWin_Sfx;
            videoPlayer.clip = currentEnemy.Videos[2];
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SPELL && enemy_Selection == GameSelections.SHIELD)
        {
            //Win
            Debug.Log("Spell Win");
            audioSource.clip = spellWin_Sfx;
            videoPlayer.clip = currentEnemy.Videos[2];
            StartCoroutine(DetermineWinnerAndRestart());
        }

        if (player_Selection == GameSelections.SWORD && enemy_Selection == GameSelections.SPELL)
        {
            //Win
            Debug.Log("Sword Win");
            audioSource.clip = swordWin_Sfx;
            videoPlayer.clip = currentEnemy.Videos[2];
            StartCoroutine(DetermineWinnerAndRestart());
        }  

    }

    IEnumerator DetermineWinnerAndRestart()
    {
        screenUI.enabled = true;
        audioSource.Play();
        videoPlayer.Play();
        yield return new WaitForSeconds(2.0f);
        animationController.ResetAnimations();
        screenUI.enabled = false;
    }

     void SetEnemySelection()
    {
        int rand = Random.Range(0, 3);

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
