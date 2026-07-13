using UnityEngine;

[CreateAssetMenu(fileName = "HandGunData", menuName = "Scriptable Objects/HandGunData")]
public class HandGunData : WeaponData
{

    protected override void Init()
    {
        damage = 7;
        fireRate = 0.5f;
        range = 8f;
    }
}
