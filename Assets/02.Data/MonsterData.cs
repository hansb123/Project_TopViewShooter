using UnityEngine;

public enum MonsterGrade
{
    Normal,
    Rare,
    Epic,
    Boss

}

public enum MonsterType
{
    Melee,
    Range
}
[CreateAssetMenu(fileName = "MonsterData", menuName = "Scriptable Objects/MonsterData")]
public class MonsterData : ScriptableObject
{
    public MonsterGrade grade;
    public MonsterType type;

    [Header("Status")]
    public float maxHp;
    public int damage;

  
    [Header("Combat")]
    public float attackRange;  // 사거리
    public float attackCoolTime; // 공격 쿨타임


    [Header("Movement")]
    public float tracespeed; //추적 속도
    public float patrolSpeed; //정찰 속도 

    [Header("Sight")]
    public float viewDistance = 10f; //Monster Fov 사거리  
    public float viewAngle = 90f;    //Monster Fov 각도


    [Header("Patrol")]
    public float patrolDistance = 3f; //정찰 거리 기본값 
    public bool horizontalPatrol = true; //정찰 => 좌우 기본값 (false => 상하)

    [Header("Drop")]
    public Item dropItem; //드랍 아이템 고정 

    [Header("Return")]
    public float traceTime = 3f;

    //[Header("alert")]
    //public float alertRadius = 20f; //주위 몬스터의 알림 반경


   
}
