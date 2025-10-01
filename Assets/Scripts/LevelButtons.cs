using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelButtons : MonoBehaviour
{
    
    [SerializeField]
    Sprite[] buttonImage;
    [SerializeField]
    TextMeshProUGUI levelNoText;

    [SerializeField]
    int levelNo;

    public GameObject[] stars;

    private void OnEnable()
    {
        ChangeSprite();
    }

    void ChangeSprite()
    {

        if (SaveManager.instance.roomData.levelDatas[RoomManagement.instance.currentRoom - 1].levels[levelNo - 1])
        {
            
            GetComponent<Image>().sprite = buttonImage[0];
            levelNoText.text = levelNo.ToString();
            foreach (GameObject star in stars)
            {
                star.SetActive(true);
            }
            RefreshStars();
        }
        else
        {
            GetComponent<Image>().sprite = buttonImage[1];
            levelNoText.text = "";
            foreach (GameObject star in stars)
            {
                star.SetActive(false);
            }

        }

        }

    void RefreshStars()
    {
        for(int i=0, n= SaveManager.instance.roomData.levelDatas[RoomManagement.instance.currentRoom - 1].stars[levelNo - 1]; i<n;i++)
        {
            stars[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
   
}
