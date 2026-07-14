using UnityEngine;

public class Bullet : Projectile
{
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    protected override void ReturnPool()
    {
        ObjectPoolManager.instance.ReturnObject("Bullet", this.gameObject);
    }
}
