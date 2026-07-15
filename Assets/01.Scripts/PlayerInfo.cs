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


   
    //기본장비 : 
   



    void UpdateHp()
    {

    }

   
    public void UpdateDefense(Item helmet, Item chest, Item leg) //defense변경.
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
