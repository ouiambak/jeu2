using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Horse : Animal, IWorker
{
    public Horse() : base("Horse") { }
    public void Work()
    {
        Debug.Log("Work");
    }
}
