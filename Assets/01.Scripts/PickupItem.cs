using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] Item item;


    //이런방식이 괜찮은가?
    //아니면 아이템별로 별도의 스크립트를 만드는것이 괜찮은가?
    ///더좋은 방법이 있는지. 멘토링 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Inventory inventory = collision.gameObject.GetComponent<Inventory>();

            if(inventory != null)
            {
                inventory.GetItem(item);
                Destroy(gameObject);
            }

           
        }
    }

}


//장착 장비인지, 소모품인지 검사 => 여기서 하지않고, Inventory가 검사 시키기.

//if (item.itemtype == ItemType.Ammo || item.itemtype == ItemType.Potion || item.itemtype == ItemType.Granade)
//{

//}


//if (item.itemtype == ItemType.Helemet || item.itemtype == ItemType.Chest || item.itemtype == ItemType.Leg)
//{

//}
