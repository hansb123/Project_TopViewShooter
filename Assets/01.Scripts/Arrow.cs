using UnityEngine;


//Bullet과 다르게 점점 느려지는 별도의 탄환이므로 다른 스크립트
public class Arrow : Projectile
{
    //감속
    float dec = 6.5f;



    protected override void FixedUpdate() //감속하는 화살 
    {
        base.FixedUpdate();

        currentSpeed -= dec * Time.fixedDeltaTime;
        currentSpeed = Mathf.Max(0, currentSpeed); //최대감속은 0으로 설정 


        rb.linearVelocity = transform.right * currentSpeed;

    }



    protected override void ReturnPool()
    {
        ObjectPoolManager.instance.ReturnObject("Arrow", this.gameObject);
    }
}

