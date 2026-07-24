using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/WeaponData")]
public class WeaponData : ScriptableObject
{
    //밑의 세 변수는 WeaponData => Arrow,Bullet으로 보내줘야할 변수 
    public int damage; 
    public float range;
    public float attackSpeed; //투사체 속도 


    //별도의 ProjectileData를 사용하기? 

    //PlayerWeapon이 사용할 변수 
    public float fireRate; //활의 경우 활 시위 당기는 시간, 총의경우 장전시간. 



}
