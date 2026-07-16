using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image;

    private Item _item;

    public Item item
    {
        get { return _item; } //프로퍼티의 사용이유? => 아이템 데이터가 바뀔 떄, UI를 자동으로 갱신하기 위해. 만약 일반 변수면 slot.item = bullet; , slot.image.sprite = bullet.itemImage; , slot.image.color  = Color.white; 와 같이.
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
  
  
}
