using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCWDragAndDrop : MonoBehaviour {
    public GameObject obj;
    public Collider2D collide_obj;
    public Vector2 prev_loc;
    public bool objPicked;
    public int ccw_token_remain;
    public GameObject trashcan;


    public ObjPickedUp pick_obj;

    private Vector3 ray;
    private Vector2 _2D;
    private WaitForSeconds timer = new WaitForSeconds(.1f);

    // Use this for initialization
    void Start () {
        objPicked = false;
        prev_loc = obj.transform.localPosition;     //set original position for object ot return to
    }
	
	// Update is called once per frame
	void Update () {
        if (ccw_token_remain > 0 && (pick_obj.game_run == false))
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    trashcan.SetActive(true);
                    ray = Camera.main.ScreenToWorldPoint(touch.position);
                    _2D = new Vector2(ray.x, ray.y);
                    if (collide_obj == Physics2D.OverlapPoint(_2D))     //check if the initial finger position is within clockwise rotation token
                    {
                        objPicked = true;                           //This object is being moved
                        pick_obj.ccwToken = true;                   //Sets the currect moving object to ccw Token
                    }

                }
                if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && objPicked)
                {
                    obj.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y, 0.0f); //move object to current finger position
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    if (objPicked)
                    {
                        StartCoroutine(touchEnd());
                    }
                }
            }
        }
    }

    private IEnumerator touchEnd()
    {
        yield return timer;
        if (pick_obj.trash)     //if placed in trash only set picked to false
        {
            pick_obj.trash = false;
            pick_obj.placed_obj = false;
        }
        if (pick_obj.placed_obj)        //if placed in empty square decrement token counter
        {
            ccw_token_remain--;
            pick_obj.placed_obj = false;
        }
        objPicked = false;
        pick_obj.ccwToken = false;
        obj.transform.localPosition = prev_loc;
    }
}
