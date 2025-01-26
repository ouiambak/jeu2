
using UnityEngine;

public class Sniper : Gun
{
    private bool _isAiming=false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!_isAiming)
            {
                Debug.Log("Is aiming");
            }
        }
        else
        {
            _isAiming = false;
        }
    }
}
