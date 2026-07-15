using System.Collections.Generic;
using UnityEngine;

public interface IReloadAmmo
{
    bool UseAmmo(int amount); //의존성을 낮추기 위해서 인터페이스를 사용함. (PlayerWeapon이 탄약을 모르게) 
}

//https://geojun.tistory.com/62#google_vignette 해당 블로그를 참조하였습니다.
public class Inventory : MonoBehaviour , IReloadAmmo
{
    //고정 슬롯 X => List 제거 ?
    public List<Item> items; 

    [SerializeField] Transform slotParent;
    [SerializeField] private Slot[] slots;

    PlayerInfo playerInfo;


    private Item helmet;
    private Item chest;
    private Item leg;

    private int ammo;
    private int potion;
    private int granade;

    

    //public Item item;
   
    void Start()
    {
        ammo = 0;
        potion = 0;
        granade = 0;
    }


    private void OnValidate() //Inspector 창에서 변수값이 수정될 때마다 자동으로 호출되는 이벤트함수.(스크립트의 속성(프로퍼티 값))
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
        playerInfo = GetComponent<PlayerInfo>();
        FreshSlot();
    }

    public void FreshSlot()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
                slots[i].item = items[i];
            else
                slots[i].item = null;
        }
    }


    public void Additem(Item _item)
    {
        if(items.Count < slots.Length)
        {
            items.Add(_item);
            FreshSlot();

        }
        else
        {
            Debug.Log("슬롯 가득참.");
        }
    }

    public void GetItem(Item item)
    {
        switch(item.itemtype)
        {
            case ItemType.Ammo:
                AddAmmo(item);
                break;

            case ItemType.Potion:
                AddPotion(item);
                break;

            case ItemType.Granade:
                AddGranade(item);
                break;

            case ItemType.Helemet:
                helmet = item;
                break;

            case ItemType.Chest:
                chest = item;
                break;

            case ItemType.Leg:
                leg = item;
                break;
        }
        playerInfo.UpdateDefense(helmet, chest, leg);
        

    }

    private void AddAmmo(Item item)
    {
        ammo += item.value;
        UiManager.instance.AmmoHudUpdate(ammo);
    }

    private void AddPotion(Item item)
    {
        potion += item.value;
        
    }

    private void AddGranade(Item item)
    {
        granade += item.value;
    }


    public bool UseAmmo(int amount)
    {
        if (ammo < amount)
            return false;

        ammo -= amount;
        UiManager.instance.AmmoHudUpdate(ammo);
        return true;
    }



}
