using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : IShowName
{
    protected string name;

    public Animal(string name)
    {
        this.name = name;
    }

    public virtual string GetName()
    {
        return name;
    }
}