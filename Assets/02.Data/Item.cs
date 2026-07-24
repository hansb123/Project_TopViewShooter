using UnityEngine;

public enum ItemType
{
    //소모품
    Ammo,
    Potion,
    StaminaPotion,

    //장착 장비
    Helemet,
    Chest,
    Leg
}

public enum ItemLevel
{
    Normal,
    Rare,
    Legendary
}


[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    
    public string itemName;
    public Sprite itemImage;

    public ItemType itemtype;
    public ItemLevel itemLevel;

    public int value; //소모품 => 개수 // 방어구 => 방어력 

}
