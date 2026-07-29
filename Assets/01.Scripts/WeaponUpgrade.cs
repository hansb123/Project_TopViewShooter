using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
   // [SerializeField] WeaponData weapondata; => 특정문, 특정 업그레이드로 하려면 WeaponData 이용 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player"))
            return;

        collision.gameObject.GetComponent<PlayerController>()?.UpgradeWeapon();


        Destroy(gameObject);
    }
}
