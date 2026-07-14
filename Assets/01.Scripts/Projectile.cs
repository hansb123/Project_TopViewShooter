using UnityEngine;

public abstract class Projectile : MonoBehaviour
{

    protected float lifeTime;
    protected float timer;
    protected int damage;
    protected float speed;
    protected float range;


    Rigidbody2D rb;


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
        if (timer >= lifeTime)
        {
            ReturnPool();
        }
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        rb.linearVelocity = transform.right * speed;
    }

    protected abstract void ReturnPool();
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {

            ReturnPool();

        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            ReturnPool();
        }

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
