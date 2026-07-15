using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] Item item;


    //이런방식이 괜찮은가?
    //아니면 아이템별로 별도의 스크립트를 만드는것이 괜찮은가?
    ///더좋은 방법이 있는지. 멘토링 


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
              //장착 장비인지, 소모품인지 검사 
            if (item.itemtype == ItemType.Ammo || item.itemtype == ItemType.Potion || item.itemtype == ItemType.Granade)
            {
               
            }


            if (item.itemtype == ItemType.Helemet || item.itemtype == ItemType.Chest || item.itemtype == ItemType.Leg)
            {
                
            }


            Destroy(gameObject);
        }
        
    }
}
