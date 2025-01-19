
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected int _ammunition;
    [SerializeField] protected int _magazineSize;
    [SerializeField] protected float _fireRate;
    [SerializeField] protected float _reloadTime;


    public virtual void Shoot()
    {
        if (_ammunition > 0)
        {
            LaunchProjectile();
            _ammunition--;
        }
        else
        {
            Debug.Log("Click! Out Of ammo!");
        }
    }

    public void Reload()
    {
        Debug.Log("Reloading...");
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(_reloadTime);
        Debug.Log("Loaded");
        _ammunition = _magazineSize;
    }

    
    protected virtual void LaunchProjectile()
    {
        EmitGunFireSound();
        Debug.Log("Launch projectile in a straight line");
    }

    protected void EmitGunFireSound()
    {
        Debug.Log("Bang");
    }




    // Update is called once per frame
    void Update()
    {

    }
}
