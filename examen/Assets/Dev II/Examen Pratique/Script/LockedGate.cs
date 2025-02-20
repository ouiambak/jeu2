
using UnityEngine;

public class LockedGate : Gate
{
    private bool _isUnlock;

    private void Start()//2pts
    {
        // Abonner la fonction SetLockState � l'event _OnToogleLock du ControlManager
        ControlManager._OnToggleLock += SetLockState;
    }

    protected override void OpenDoor() //surcharg� de l'enfant //2pts
    {
        
        // Ouvrir la porte si la porte est d�bar�e
        if (_isUnlock)
        {
            _doorAnimator.SetBool("Open", true);
            _doorAnimator.SetBool("Close", false);
        }
        base.OpenDoor();
    }

    private void SetLockState(bool situation) //sp�cifique � l'enfant  //2 pts
    {
    // Barrer ou d�barer la porte (applique la valeur apropri�e � la variable _isUnlock)
        _isUnlock = situation;
    }

}
