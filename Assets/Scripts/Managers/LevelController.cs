using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelController : MonoBehaviour
{
    

    [SerializeField]
    GameObject[] characters;

    [SerializeField]
    int currentLevel;

    [HideInInspector]
    public bool gameStarted = false;
    public int shots = 3;
    public bool canShoot = true;

    private void Awake()
    {
        GameCanvasManager.instance.shotsText.text = "SHOTS: " + shots.ToString();
    }

    private void OnDisable()
    {
        //instance = null;
    }

    public bool CheckGameStatus()
    {
        bool key = true;
        foreach(var ch in characters)
        {
            if(ch.GetComponentInChildren<Characters>().level!=1)
            {
                key = false;
            }
            
        }
        

        return key;
    }

    public void DecreamentShot()
    {
        shots--;
        GameCanvasManager.instance.shotsText.text = "SHOTS: " + shots.ToString();
        canShoot = false;
        StartCoroutine(CheckGameState());

    }


    IEnumerator CheckGameState()
    {

        yield return new WaitForSeconds(3f);

        if (CheckGameStatus())
        {
            
            canShoot = false;
            UpdateLevel();
            GameCanvasManager.instance.winPanel.SetActive(true);
            GameCanvasManager.instance.ShowStars();
        }


        //Total Shots Over
        if (shots == 0)
        {

            if (CheckGameStatus())
            { 
                UpdateLevel();
                GameCanvasManager.instance.winPanel.SetActive(true);
                GameCanvasManager.instance.ShowStars();
            }
            else
            {
                GameCanvasManager.instance.lossPanel.SetActive(true);
            }
            canShoot = false;
        }
        canShoot = true;
    }

    void UpdateLevel()
    {
        if(currentLevel<15)
        {
            SaveManager.instance.roomData.levelDatas[RoomManagement.instance.currentRoom - 1].levels[currentLevel] = true;
            SaveManager.instance.UpdateData();
        }
        
    }

    

    public void SetLevel(int level)
    {
        this.currentLevel = level;
    }

}
