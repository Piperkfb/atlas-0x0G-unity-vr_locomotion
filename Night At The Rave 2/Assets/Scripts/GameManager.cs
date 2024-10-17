using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public NearFarInteractor nearFar;
    public OuchScreen ouch;
    public GameOver gameOver;
    public float PlayerHealth = 3f;

    // Update is called once per frame


    public void GameOver()
    {
        Debug.Log("gameovered");
        
        //disable character controller
        //disable zombie movements
        nearFar.enableFarCasting = true;
        Time.timeScale = 0f;
        //canvas appears in front of player
        gameOver.SpawnCanvas();
    }
    public void Restart()
    {
        Debug.Log("restarted");
        nearFar.enableFarCasting = false;
        Time.timeScale = 1f;
        gameOver.DisableCanvas();
        SceneManager.LoadScene("RaveMap1");
    }
    public void PlayerDamage()
    {
        if (PlayerHealth == 2)
        {
            ouch.Ouch1();
        }
        else if (PlayerHealth == 1)
        {
            ouch.Ouch2();
        }
        else if (PlayerHealth <= 0)
        {
            ouch.Ouch3();
            GameOver();
        }
    }
}
