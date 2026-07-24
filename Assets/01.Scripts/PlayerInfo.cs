using UnityEngine;
using System;


enum WeaponType
{
    Bow,
    HandGun,
    MiniGun
}
public class PlayerInfo : MonoBehaviour, IDamageable
{
    //TODO : 이벤트로 관리 => 서버가 추가되는 것이라면 해야하는 것, 그러나 지금처럼 규모가 적은 프로젝트에선 굳이?  =>  시간 남으면 리팩토링 
    public event Action<int> OnHpChanged;
    public event Action<float> OnStaminaChanged;



    float hp;
    float stamina;
    float maxStamina; 
    float staminaConsum;
    float staminaRecovery;
    int defense;
    

    private void Start()
    {
        hp = 400;
        stamina = 100f;
        maxStamina = stamina;
        staminaConsum = 20f;
        staminaRecovery = 10f;
        UiManager.instance.HpHudUpdate(hp);
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

            // 여기서 직접호출 하지않고 변경됨을 알림 (이벤트) => 여기서 UiManager 호출 ?
            UiManager.instance.StaminaHudUpdate(stamina / maxStamina);

            //OnStaminaChanged?.Invoke(stamina / maxStamina);


            return true;

        }
        return false;

    }



   
    public void UpdateDefense(Item helmet, Item chest, Item leg) //defense변경.
    {
        int helmetValue = 0;
        int chestValue = 0;
        int legValue = 0;
        defense = 0;

        if(helmet != null)
        {
            helmetValue = helmet.value;
            defense += helmet.value;
            
        }

        if(chest != null)
        {
            chestValue = chest.value;
            defense += chest.value;
        }

        if(leg != null)
        {
            legValue = leg.value;
            defense += leg.value;
        }

        UiManager.instance.EquipText(helmetValue, chestValue, legValue);


    }

    public void AddHp(int _potionValue)
    {
        hp += _potionValue;
        if(hp >= 400)
        {
            hp = 400;
        }
        UiManager.instance.HpHudUpdate(hp);
    }

    public void AddStamina(int _staminaValue)
    {
        stamina += _staminaValue;
        if (stamina >= 100)
        {
            stamina = 100f;
        }
        UiManager.instance.StaminaHudUpdate(stamina);
    }

    public void TakeDamage(float dmg)
    {
        
        hp -= (dmg-defense);
        UiManager.instance.HpHudUpdate(hp);
    }

   



}
