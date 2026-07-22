using UnityEngine;

[CreateAssetMenu(fileName = "MonsterWeaponData", menuName = "Scriptable Objects/MonsterWeaponData")]
public class MonsterWeaponData : ScriptableObject
{
    [Header("Combat")]
    public float damage;
    public float attackCoolTime; // 공격 쿨타임

    [Header("Projectile/DashAttack")] //원거리 => Projectile의 속도   /  근거리 => 몸통박치기 속도
    public float speed = 5;  
    public float range;



}
