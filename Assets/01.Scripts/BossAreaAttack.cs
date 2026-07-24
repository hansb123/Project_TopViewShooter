using UnityEngine;
using DG.Tweening;

public class BossAreaAttack : MonoBehaviour
{
    float maxRadius = 5f;
    float duration = 3f;
    [SerializeField]LayerMask playerLayer;

    float damage;




    //https://mingyu0403.tistory.com/6 ÂüÁ¶ÇÔ 
    public void Init(float damage)
    {
        this.damage = damage * 2;

        transform.localScale = Vector2.zero;


        transform.DOScale(Vector3.one * maxRadius, duration).SetEase(Ease.Linear).OnComplete(() =>
        {
        Collider2D hit = Physics2D.OverlapCircle
        (
            transform.position,
            maxRadius,
            playerLayer);

           if(hit != null)
            {
                hit.GetComponent<IDamageable>()?.TakeDamage(this.damage);
            }

            Destroy(gameObject);

        });
        
        
    }
}
