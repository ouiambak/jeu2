using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] protected Animator _doorAnimator;
    private void Awake()//2pts
    {
        //Abonner les fonctions OpenDoor et CloseDoor au _OnGateOpen et au _OngateCloseEvent du ControlManager
        ControlManager._OnGateOpen += OpenDoor;
        ControlManager._OnGateOpen += CloseDoor;
    }
    
    protected virtual void CloseDoor() //1 pts
    {
        //Assigner les booléens de l'animator de la portes (Le "Open" et le "Close) pour fermer la porte"
        _doorAnimator.SetBool("Open", false);
        _doorAnimator.SetBool("Close", true);
    }

    protected virtual void OpenDoor() //1 pts
    {
        //Assigner les booléens de l'animator de la portes (Le "Open" et le "Close) pour ouvrir la porte"
        _doorAnimator.SetBool("Open", true);
        _doorAnimator.SetBool("Close", false);
    }
    
}
