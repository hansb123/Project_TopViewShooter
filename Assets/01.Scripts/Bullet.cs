using UnityEngine;

public class Bullet : Projectile
{

    protected override void FixedUpdate()
    {
        base.FixedUpdate();


         rb.linearVelocity = transform.right * currentSpeed;

    }

    protected override void ReturnPool()
    {
        ObjectPoolManager.instance.ReturnObject("Bullet", this.gameObject);
    }

    
}
