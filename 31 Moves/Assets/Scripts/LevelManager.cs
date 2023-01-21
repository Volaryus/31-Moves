using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    int level;
    public bool isMenu;
    public GameObject[] levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("Level");
        if (level == 0) level = 1;
        if (isMenu)
        {
            for (int i = 0; i < level; i++)
            {
                levelButtons[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp(int number)
    {
        if (number > level)
        {
            level = number;
            PlayerPrefs.SetInt("Level", level);
        }
    }
}
