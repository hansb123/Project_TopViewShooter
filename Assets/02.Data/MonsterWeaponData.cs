using UnityEngine;

[CreateAssetMenu(fileName = "MonsterWeaponData", menuName = "Scriptable Objects/MonsterWeaponData")]
public class MonsterWeaponData : ScriptableObject
{
    [Header("Damage")]
    public float damage;


    [Header("Projectile")] //원거리 몬스터에만 사용 
    public float speed = 5; 
    public float range;



}
