using System;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Bullet과 다르게 점점 느려지는 별도의 탄환이므로 다른 스크립트
    float lifeTime;
    float timer;



    int damage;
    float speed;
    float range;
  

    Rigidbody2D rb;
    Vector2 dir; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeTime = 5f;
        timer = 0f;
    }

    private void OnEnable()
    {
        timer = 0f;
    }
    void Update()
    {
        if(timer >= lifeTime)
        {
            ReturnPool();
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        rb.linearVelocity = transform.right * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            ReturnPool();

        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            ReturnPool();
        }
        
    }

    void ReturnPool()
    {
        ObjectPoolManager.instance.ReturnObject("Arrow",this.gameObject);
    }


    public void SetDamage(int dmg)
    {
        damage = dmg;
    }

    public void SetSpeed(float spd)
    {
        speed = spd;
    }

    public void SetRange(float rng)
    {
        range = rng;
    }

}

