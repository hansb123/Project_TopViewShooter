using UnityEngine;


public class PickupItem : MonoBehaviour 
{
    [SerializeField] Item item;



   public void Interact(GameObject player)
    {

        Inventory inventory = player.GetComponent<Inventory>();

        if (inventory == null)
            return;

        inventory.GetItem(item);
        Destroy(gameObject);

        


    }










}



