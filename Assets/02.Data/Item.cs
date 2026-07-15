using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    //https://geojun.tistory.com/62#google_vignette 해당 블로그를 참조하였습니다.
    public string itemName;
    public Sprite itemImage;
}
