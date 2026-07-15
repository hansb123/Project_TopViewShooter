using System.Collections.Generic;
using UnityEngine;


//https://geojun.tistory.com/62#google_vignette 해당 블로그를 참조하였습니다.
public class Inventory : MonoBehaviour
{
    public List<Item> items;

    [SerializeField] Transform slotParent;
    [SerializeField] private Slot[] slots;

    //public Item item;
   
    void Start()
    {
        
    }


    private void OnValidate() //Inspector 창에서 변수값이 수정될 때마다 자동으로 호출되는 이벤트함수.(스크립트의 속성(프로퍼티 값))
    {
        slots = slotParent.GetComponentsInChildren<Slot>();
    }

    private void Awake()
    {
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


}
