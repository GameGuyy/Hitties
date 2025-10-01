using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameCanvasManager : MonoBehaviour
{
    public static GameCanvasManager instance;

    public TextMeshProUGUI shotsText;
    public GameObject pausePanel;
    public GameObject winPanel;
    public GameObject lossPanel;

    public bool tapKill = false;
    public GameObject extraShot;

    public GameObject tapToDestory;

    [SerializeField]
    GameObject[] stars;

    public int starCount;

    void ClosePanels()
    {
        GameObject[] panels = { winPanel, pausePanel, lossPanel };
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }



   
    public void OpenLevelsPanel()
    {

        LevelManager.instance.DestroyLevel();
        ResetStars();
        ClosePanels();
        RoomManagement.instance.gameCanvas.SetActive(false);
        RoomManagement.instance.mainmenuCanvas.SetActive(true);
        
    }

    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);

    }

    public void ClosePausePanel()
    {
        
        pausePanel.SetActive(false);
    }

    public void RestartLevel()
    {
        ResetStars();
        ClosePanels();
        LevelManager.instance.DestroyLevel();
        LevelManager.instance.InstantiateNewLevel(LevelManager.instance.level);
    }

    public void NextLevel()
    {
        
        ResetStars();
        ClosePanels();
        LevelManager.instance.DestroyLevel();
        LevelManager.instance.InstantiateNewLevel(LevelManager.instance.level + 1);

    }

    public void ShowStars()
    {
        if(starCount >SaveManager.instance.roomData.levelDatas[RoomManagement.instance.currentRoom-1].stars[LevelManager.instance.level-1])
        {
            SaveManager.instance.roomData.levelDatas[RoomManagement.instance.currentRoom - 1].stars[LevelManager.instance.level - 1] = starCount;
            SaveManager.instance.UpdateData();
        }

        for(int i=0;i<starCount;i++)
        {
            stars[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    void ResetStars()
    {
        starCount = 0;
        for (int i = 0; i < 3; i++)
        {
            stars[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }


    public void ExtraShot()
    {
        var lc = FindObjectOfType<LevelController>();
        lc.shots++;
        shotsText.text = "SHOTS: " + lc.shots.ToString();
        extraShot.SetActive(false);
        
    }

    public void TapToShoot()
    {
        FindObjectOfType<LevelController>().canShoot = false;
        tapToDestory.SetActive(false);
        tapKill = true;

    }



}
