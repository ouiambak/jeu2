using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ForesGenerator : MonoBehaviour
{
    public enum ForestShape
    {
        square,
        circle
    }
    [Tooltip("List of all trees to instantiate")]
    [SerializeField] private List<Tree> _treeList;
    [SerializeField] private GameObject _Prefabtree;

    [Foldout("Parameters")]
    [AllowNesting]
    [SerializeField] private ForestShape _shape;

    [Foldout("Parameters")]
    [AllowNesting]
    [SerializeField] private Vector3 _offset;

    [Foldout("Parameters")]
    [AllowNesting]
    [Range(0f, 10f)]
    [SerializeField] private float _forestRange;

    private List<GameObject> _allTree;

    [Button]
    public void AddTree()
    {
        if (_shape == ForestShape.square)
        {
            foreach (Tree tree in _treeList)
            {
                Vector3 randomPos = _offset + new Vector3(Random.Range(-_forestRange, _forestRange), 0, Random.Range(-_forestRange, _forestRange));
                Quaternion randpmRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
                GameObject newTree = Instantiate(_Prefabtree, randomPos, randpmRotation);
                _allTree.Add(newTree);
                newTree.transform.localScale = new Vector3(tree._raduis, tree._height, tree._raduis);
            }
        }
        if (_shape == ForestShape.circle)
        {
            foreach (Tree tree in _treeList)
            {
                Vector3 randomPos = Random.insideUnitSphere * _forestRange;
                randomPos = _offset + new Vector3(randomPos.x, 0, randomPos.z);
                Quaternion randpmRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));
                GameObject newTree = Instantiate(_Prefabtree, randomPos, randpmRotation);
                _allTree.Add(newTree);
                newTree.transform.localScale = new Vector3(tree._raduis, tree._height, tree._raduis);
            }
        }

    }
    [Button]
    public void RemoveAllTree()
    {
        for (int i = _allTree.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(_allTree[i]);
            _allTree.RemoveAt(i);
        }
    }
}
