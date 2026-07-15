using UnityEngine;

enum WeaponType
{
    Bow,
    HandGun,
    MiniGun
}
public class PlayerInfo : MonoBehaviour
{
    float hp;
    int defense;


  
    [SerializeField] private Item helmet; 
    [SerializeField] private Item chest;
    [SerializeField] private Item leg;

    [SerializeField] Inventory inventory;



    void UpdateHp()
    {

    }

   
    public void UpdateDefense() //defenseº¯°æ.
    {
        defense = 0;

        if(helmet != null)
        {
            defense += helmet.value;
        }

        if(chest != null)
        {
            defense += chest.value;
        }

        if(leg != null)
        {
            defense += leg.value;
        }
    }


}
