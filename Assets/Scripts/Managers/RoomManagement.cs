using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManagement : MonoBehaviour
{

    [Header("Canvas")]
    public GameObject gameCanvas;
    public GameObject mainmenuCanvas;

    public GameObject MainPanel;
    public GameObject RoomsPanel;
    public GameObject LevelsPanel;
    public GameObject buyPanel;

    public GameObject[] lbs;

    int i = 0;

    public int currentRoom = 1;
    public static RoomManagement instance;
    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    private void OnEnable()
    {
        
        foreach(var lb in lbs)
        {
            lb.SetActive(true);
        }
    }

    private void OnDisable()
    {
        foreach (var lb in lbs)
        {
            lb.SetActive(false);
        }
    }

    public void OpenLevelsPanel(int currentRoomNo)
    {
        currentRoom = currentRoomNo;
        if (SaveManager.instance.roomData.room[currentRoomNo - 1])
        {
            LevelsPanel.SetActive(true);
            //Make Array Later
        }
        else
        {
            buyPanel.SetActive(true);
        }
    }

    public void CloseLevelPanel()
    {
        LevelsPanel.SetActive(false);
        currentRoom = -1;

    }

    public void OpenRoomPanel()
    {
        RoomsPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    public void CloseRoomPanel()
    {
        RoomsPanel.SetActive(false);
        MainPanel.SetActive(true);
    }

    public void BuyItem()
    {
        //Check Price According to RoomData file
        //Unlock and subtract coins
    }

    public void CloseBuyPanel()
    {
        buyPanel.SetActive(false);
    }

    


}
