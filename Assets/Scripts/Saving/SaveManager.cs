using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public RoomData roomData;

    private void Awake()
    {
        MakeInstance();
        Load();
        
    }

    void Save()
    {
        PlayerPrefs.SetString("system", SaveHelper.Serialize<RoomData>(roomData));
    }


    void Load()
    {
        if(PlayerPrefs.HasKey("system"))
        {
            roomData = SaveHelper.Deserialize<RoomData>(PlayerPrefs.GetString("system"));

        }else
        {
            roomData = new RoomData();
            roomData.levelDatas = new LevelData[6];
            for (int i = 0; i < roomData.levelDatas.Length; i++)
            {
                roomData.levelDatas[i] = new LevelData();
            }
            
        }

        
    }

    public void UpdateData()
    {
        Save();
        Load();
    }
    void MakeInstance()
    {
        if(instance == null )
        {
            instance = this;
        }
    }

    private void OnDisable()
    {
        instance = null;
    }

    
}

