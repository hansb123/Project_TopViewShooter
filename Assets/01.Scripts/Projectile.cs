
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    protected float lifeTime; //기본적으로 발사체들의 사거리가 존재하지만, 게임 내에 잔류할 가능성이 있으므로 
    protected float timer;

    protected int damage;
    protected float speed;
    protected float currentSpeed;
    protected float range;


    protected Rigidbody2D rb;

    Vector3 startPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeTime = 5f;
        timer = 0f;
    }

    protected void OnEnable()
    {
        timer = 0f;
        
        
    }


    private void Update()
    {
        if (timer >= lifeTime)
        {
            ReturnPool();
        }

        if (Vector3.Distance(startPos, transform.position) >=range) //사거리 제한 
        {
            ReturnPool();
        }
    }

    protected virtual void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;


    }
  

    protected abstract void ReturnPool();
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log($"준 데미지 :{damage}");
            ReturnPool();

        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            ReturnPool();
        }

    }

    public void Init(int dmg, float spd, float rng) 
    {
        damage = dmg;
        speed = spd;
        range = rng;

        startPos = transform.position;
        currentSpeed = speed;
    }

}
