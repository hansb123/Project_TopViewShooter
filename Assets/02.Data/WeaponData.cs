using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    //밑의 세 변수는 WeaponData => Arrow,Bullet으로 보내줘야할 변수 
    public int damage; 
    public float range;
    public float attackSpeed; //투사체 속도 


    //PlayerWeapon이 사용할 변수 
    public float fireRate; //공격 주기 



}
