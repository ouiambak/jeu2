
using UnityEngine;

public class LockedGate : Gate
{
    private bool _isUnlock;

    private void Start()//2pts
    {
        // Abonner la fonction SetLockState à l'event _OnToogleLock du ControlManager
        ControlManager._OnToggleLock += SetLockState;
    }

    protected override void OpenDoor() //surchargé de l'enfant //2pts
    {
        
        // Ouvrir la porte si la porte est débarée
        if (_isUnlock)
        {
            _doorAnimator.SetBool("Open", true);
            _doorAnimator.SetBool("Close", false);
        }
        base.OpenDoor();
    }

    private void SetLockState(bool situation) //spécifique à l'enfant  //2 pts
    {
    // Barrer ou débarer la porte (applique la valeur apropriée à la variable _isUnlock)
        _isUnlock = situation;
    }

}
