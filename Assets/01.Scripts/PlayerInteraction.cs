using UnityEngine;
using UnityEngine.InputSystem;

//TODO : 추후 확장성 리팩토링  (상호작용의 경우 아이템 뿐만아닌 다른것도 있으므로  
//public interface IOverlapTarget
//{
//    void interact(GameObject player);
//    string GetInteractionText();
//}

public class PlayerInteraction : MonoBehaviour
{
    //overlap이용하여 아이템 습득 
    [SerializeField] Transform centerPoint;

    float radius = 1.2f;

    LayerMask targetLayer;

    
    private void Start()
    {
        targetLayer = 1<<8; //6번비트 => item 검사 
    }

    private void Update()
    {
        Collider2D hitColliders = Physics2D.OverlapCircle(centerPoint.position, radius, targetLayer);

        if(hitColliders != null)
        {
            UiManager.instance.GetItemText();

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                PickupItem item = hitColliders.GetComponent<PickupItem>();

                if(item != null)
                {
                    SoundManager.instance.PlaySFX(SFXType.GetItem);
                    item.Interact(gameObject);
                }
            }
   
        }
        else
        {
            UiManager.instance.HideItemText();
        }
        
    }

    private void OnDrawGizmosSelected() //TODO : 빌드 전에 제거 
    {
        if (centerPoint == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(centerPoint.position, radius);
    }
}
