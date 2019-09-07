using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [System.Serializable]
    public class Level
    {
        public string LevelText;
        public bool Completed;
        public bool Playable;
        public int Data;
        public int Unlocked;
        
    }

    public Transform WorldSelect;
    public GameObject WorldButton;
    public GameObject NotWorldButton;
    public GameObject Gaia1;
    public GameObject Gaia2;
    public GameObject Gaia3;
    public GameObject LevelCover;
    public GameObject LevelSelect;
    public List<Level> levelList;

    public GameObject Menu_background;
    public GameObject Game_background;

    public int[] Level_Array = new int[3] { 1, 0, 0 };
    
    

	// Use this for initialization
	void Start () {
        DeleteAll();
        FillList();
	}

    void FillList()
    {
        foreach (var level in levelList)
        {
            GameObject newbutton = Instantiate(WorldButton) as GameObject;
            LevelButton button = newbutton.GetComponent<LevelButton>();
            button.LevelText.text = level.LevelText;
            //1-1, 1-2, 1-3, 1-4, ... etc.

            button.unlocked = level.Unlocked;
            button.GetComponent<Button>().interactable = level.Playable;
            button.GetComponent<Button>().onClick.AddListener(() => loadLevels(button.LevelText.text));
            newbutton.AddComponent<BoxCollider2D>();

            if (PlayerPrefs.GetInt(button.LevelText.text) == 1)
            {
                button.unlocked = 1;
                level.Playable = true;
            }
            else
            {
                button.unlocked = 0;
                level.Playable = false;
            }

            newbutton.transform.SetParent(WorldSelect);
        }
        SaveAll();
    }
	
    void SaveAll()
    {
        if(PlayerPrefs.HasKey("1"))
        {
            return;
        }
            
        /* GameObject[] allButtons = GameObject.FindGameObjectsWithTag("LevelButton");
        foreach(GameObject buttons in allButtons)
        {
            LevelButton button = buttons.GetComponent<LevelButton>();
            PlayerPrefs.SetInt(button.LevelText.text, button.unlocked);
        }*/
    }

    void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }

    void loadLevels(string value)
    {
        
        if(value.Equals("1"))
        {
            print("level1");
            if (Level_Array[0] == 1)
            {
                LevelSelect.SetActive(false);
                Gaia1.SetActive(true);
                Menu_background.SetActive(false);
                Game_background.SetActive(true);
                Gaia1.GetComponent<LevelReset1>().GameReset();
            }
            
        }
        if (value.Equals("2"))
        {
            print("level2");
            print(Level_Array[1]);
            if (Level_Array[1] == 1)
            {
                print("why");
                LevelSelect.SetActive(false);
                Gaia2.SetActive(true);
                Menu_background.SetActive(false);
                Game_background.SetActive(true);
                Gaia2.GetComponent<LevelReset2>().GameReset();
            }
        }
        if (value.Equals("3"))
        {
            if (Level_Array[2] == 1)
            {
                LevelSelect.SetActive(false);
                Gaia3.SetActive(true);
                Menu_background.SetActive(false);
                Game_background.SetActive(true);
                Gaia3.GetComponent<LevelReset3>().GameReset();
            }
        }
    }

}

