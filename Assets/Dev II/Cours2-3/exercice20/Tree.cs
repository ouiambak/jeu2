using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NaughtyAttributes;

[Serializable]
public class Tree 
{
    [MinValue (2f), MaxValue(10f)]
    public float _lentghOfBranch;
    [MinValue(0), MaxValue(10)]
    public int _numberOfBranch;

    public float _raduis;
    public float _height;

    public bool _hasLeaf;
    [AllowNesting]
    [ShowIf("_hasLeaf")]
    public float _sizeOfLeaf;
    [AllowNesting]
    [ShowIf("_hasLeaf")]
    public int _numberOfLeaf;
    [AllowNesting]
    [ShowIf("_hasLeaf")]
    public Color _leafColor;
}
