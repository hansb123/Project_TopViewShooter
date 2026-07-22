using UnityEngine;

public class MonsterProjectile : MonoBehaviour
{
    protected float lifeTime; //기본적으로 발사체들의 사거리가 존재하지만, 게임 내에 잔류할 가능성이 있으므로 
    protected float timer;

    protected float damage;
    protected float speed;
    protected float currentSpeed;
    protected float range;

    protected Rigidbody2D rb;

    Vector3 startPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
       
        lifeTime = 5f;
        timer = 0f;
    }

    protected void OnEnable()
    {
        timer = 0f;
        rb.linearVelocity = Vector2.zero;


    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            ReturnPool();
        }

        if (Vector3.Distance(startPos, transform.position) >= range) //사거리 제한 
        {
            ReturnPool();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = transform.right * currentSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log($"준 데미지 :{damage}");
            ReturnPool();

        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log($"준 데미지 :{damage}");
            ReturnPool();
        }

    }

    private void ReturnPool()
    {
        ObjectPoolManager.instance.ReturnObject("MonsterBullet", this.gameObject);
    }


    public void Init(float dmg, float spd, float rng)
    {
        damage = dmg;
        speed = spd;
        range = rng;

        startPos = transform.position;
        currentSpeed = speed;
    }
}
