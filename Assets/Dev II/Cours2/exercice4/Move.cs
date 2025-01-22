using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    enum Direction{
        Gauche,
        Droite,
        Haut,
        Bas,
        Front,
        Back
    };
    [SerializeField] private Direction _currentDirection;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _speed = 5f;

    void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        Vector3 movement = Vector3.zero;

        switch (_currentDirection)
        {
            case Direction.Gauche:
                movement = Vector3.left;
                break;
            case Direction.Droite:
                movement = Vector3.right;
                break;
            case Direction.Haut:
                movement = Vector3.up;
                break;
            case Direction.Bas:
                movement = Vector3.down;
                break;
            case Direction.Front:
                movement = Vector3.forward;
                break;
            case Direction.Back:
                movement = Vector3.back;
                break;
        }

        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
