using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public int ID { get; set; }
    public string WorldName { get; set; }
    public bool Completed { get; set; }
    public int Data { get; set; }
    public bool Locked { get; set; }

    public Level(int id, string worldName, bool completed, int data, bool locked)
    {
        this.ID = id;
        this.WorldName = worldName;
        this.Completed = completed;
        this.Data = data;
        this.Locked = locked;
    }

    public void Complete(int data)
    {
        this.Completed = true;
        this.Data = data;
    }

    public void Lock()
    {
        this.Locked = true;
    }

    public void Unlocked()
    {
        this.Locked = false;
    }
}
