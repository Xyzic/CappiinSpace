using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelReset3 : MonoBehaviour {
    public EmptyReset Empty;
    public ScoreCounter ScoreCount;
    public HealthPowerupDrag HealthDrag;
    public TempPowerupDrag TempDrag;
    public CWDragAndDrop CWDrag;
    public CCWDragAndDrop CCW_Drag;
    public StartGame Start_Game;
    public ObjPickedUp Objects;
    public EndSpot End;

    public GameObject Professor;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameReset()
    {
        Empty.Reset_Game();
        ScoreCount.score = 0;
        ScoreCount.TotalData = 4;
        HealthDrag.health_token_remain = 1;
        TempDrag.temp_token_remain = 1;
        CWDrag.clock_token_remain = 4;
        CCW_Drag.ccw_token_remain = 3;
        Start_Game.trials = 3;
        Objects.Obj_Reset();
        End.exit = false;
        End.EndRecover();


        Professor.SetActive(true);       

    }
}
