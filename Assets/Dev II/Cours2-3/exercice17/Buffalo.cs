using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Buffalo : Animal, IWorker
{
    public Buffalo() : base("Buffalo") { }
    public void Work()
    {
        Debug.Log("Work");
    }
}
