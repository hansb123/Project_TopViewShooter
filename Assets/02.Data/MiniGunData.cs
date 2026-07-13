using UnityEngine;

[CreateAssetMenu(fileName = "MiniGunData", menuName = "Scriptable Objects/MiniGunData")]
public class MiniGunData : WeaponData
{

    protected override void Init()
    {
        damage = 15;
        fireRate = 0.1f;
        range = 15f;
    }
}
