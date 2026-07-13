using UnityEngine;

[CreateAssetMenu(fileName = "BowData", menuName = "Scriptable Objects/BowData")]
public class BowData : WeaponData
{
    protected override void Init()
    {
        damage = 10;
        fireRate = 1f;
        range = 5f;
    }
}
