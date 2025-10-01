using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int[] levelShots;
    public GameObject[] levels;
    GameObject newLevel;

    public int level;
    public static LevelManager instance;

    LevelController levelController;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    private void OnDisable()
    {
        instance = null;
    }
    public void InstantiateNewLevel(int currentLevelNo)
    {
        
        if (SaveManager.instance.roomData.levelDatas[RoomManagement.instance.currentRoom - 1].levels[currentLevelNo - 1])
        {
            level = currentLevelNo;
            RoomManagement.instance.mainmenuCanvas.SetActive(false);
            RoomManagement.instance.gameCanvas.SetActive(true);
            GameCanvasManager.instance.tapToDestory.SetActive(true);
            GameCanvasManager.instance.extraShot.SetActive(true);
            newLevel = Instantiate<GameObject>(levels[currentLevelNo - 1], Vector3.zero, Quaternion.identity);
            levelController = FindObjectOfType<LevelController>();
            levelController.shots = levelShots[currentLevelNo - 1];
            levelController.SetLevel(currentLevelNo);

        }
        else
        {
            //Open Panel saying Level Locked
        }

    }

    public void DestroyLevel()
    { 
        
        Destroy(newLevel.gameObject);

    }

    

}
