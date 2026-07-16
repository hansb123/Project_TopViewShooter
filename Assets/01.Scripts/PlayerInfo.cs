using UnityEngine;
using System;




enum WeaponType
{
    Bow,
    HandGun,
    MiniGun
}
public class PlayerInfo : MonoBehaviour
{
    public event Action<int> OnHpChanged;
    public event Action<float> OnStaminaChanged;

    //UiManager => PalyerInfo의 OnHpChanged, OnStaminaChanged 구독을 하느냐

    //PlayerInfo => UiManager의 싱글톤을 사용하느냐.차이 => 뭐가 좋은 코딩인지, 확인 후 리팩토링 진행 


    int hp;
    float stamina;
    float maxStamina; 
    float staminaConsum;
    float staminaRecovery;
    int defense;

    private void Start()
    {
        hp = 100;
        stamina = 100f;
        maxStamina = stamina;
        staminaConsum = 20f;
        staminaRecovery = 10f;
        UiManager.instance.HpHudUpdate(hp);
    }

    void UpdateHp()
    {

    }

    private void Update()
    {
       
    }

    public void RecoverStamina()
    {
        float amount = staminaRecovery * Time.deltaTime;

        stamina += amount;
        if(stamina >= maxStamina)
        {
            stamina = maxStamina;
        }
        UiManager.instance.StaminaHudUpdate(stamina / maxStamina);


    }
    public bool TryUseStamina()
    {
        float amount = staminaConsum * Time.deltaTime;
        if (stamina < amount)
        {
          
            return false;
        }
        else if (stamina >= amount)
        {
            stamina -= amount;
            UiManager.instance.StaminaHudUpdate(stamina / maxStamina);
            return true;

        }
        return false;

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

    public void AddHp(int _potionValue)
    {
        hp += _potionValue;
        if(hp >= 100)
        {
            hp = 100;
        }
        UiManager.instance.HpHudUpdate(hp);
    }


}
