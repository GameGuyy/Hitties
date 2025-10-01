using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    

    [SerializeField]
    int coins;

    public void AddCoin(int value)
    {
        coins += value;
        PlayerPrefs.SetInt("coins", coins);
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt("coins", 0);
    }

    

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
    
    

}
