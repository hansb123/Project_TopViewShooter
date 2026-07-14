using UnityEngine;


//Bullet과 다르게 점점 느려지는 별도의 탄환이므로 다른 스크립트
public class Arrow : Projectile
{
    protected override void ReturnPool()
    {
        ObjectPoolManager.instance.ReturnObject("Arrow", this.gameObject);
    }
}

