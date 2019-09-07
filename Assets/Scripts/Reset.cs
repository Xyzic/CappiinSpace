using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Reset : MonoBehaviour {
    public EmptyReset Empty;
    public Collider2D ResetButton;
    public ObjPickedUp Game;

    private Vector3 ray;
    private Vector2 _2D;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                ray = Camera.main.ScreenToWorldPoint(touch.position);
                _2D = new Vector2(ray.x, ray.y);
                if (ResetButton == Physics2D.OverlapPoint(_2D))     //check if the initial finger position is within clockwise rotation token
                {
                    if(Game.game_run == false)
                    {
                        Empty.Empty_Reset();
                    }                         
                }
            }
        }
    }

}
