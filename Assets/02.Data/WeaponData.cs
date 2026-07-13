using UnityEngine;

public abstract class WeaponData : ScriptableObject
{
    protected float damage; 
    protected float range;
    protected float fireRate; //공격 주기 


    protected abstract void Init();

}
