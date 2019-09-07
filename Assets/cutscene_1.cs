using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutscene_1 : MonoBehaviour {

    public GameObject C1S1P1;
    public GameObject C1S1P2;
    public GameObject C1S2P1;
    public GameObject C1S2P2;
    public GameObject C1S2P3;
    public GameObject C1S3P1;
    public GameObject C1S3P2;
    public GameObject C1S3P3;
    public int tapCount = 0;
    public int endFlag;

    public GameObject LevelSelect;
    public GameObject Cutscene;

    public bool CutScene_active;

    // Use this for initialization
    void Start () {

        endFlag = 0;
       
    }

    // Update is called once per frame
    void Update () {
        if (CutScene_active)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Ended)
                {
                    onTap();
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                onTap();
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    onTap();
        //}
        //how to get taps working? don't know how to test on my computer lol
        /*
        if (Input.touchCount == 1)
        {
            onTap();
        }
        */
	}

    void onTap ()
    {
        tapCount++;

        switch (tapCount)
        {
            case 1:
                C1S1P1.SetActive(true);
                break;
            case 2:
                C1S1P2.SetActive(true);
                break;

            case 3:
                C1S1P1.SetActive(false);
                C1S1P2.SetActive(false);

                C1S2P1.SetActive(true);
                break;

            case 4:
                C1S2P1.SetActive(false);
                C1S2P2.SetActive(true);
                break;

            case 5:
                
                C1S2P2.SetActive(false);
                C1S2P3.SetActive(true);
                break;

            case 6:
                
                C1S2P3.SetActive(false);

                C1S3P1.SetActive(true);
                break;

            case 7:
                C1S3P2.SetActive(true);
                break;

            case 8:
                C1S3P3.SetActive(true);
                break;

            case 9:
                endFlag = 1;
                break;

            default:
                break;
        }

        if (endFlag == 1)
        {
            tapCount = 0;
            C1S3P1.SetActive(false);
            C1S3P2.SetActive(false);
            C1S3P3.SetActive(false);
            CutScene_active = false;
            endFlag = 0;
            LevelSelect.SetActive(true);
            Cutscene.SetActive(false);
        }
    }

}
