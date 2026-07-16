using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;


    [SerializeField] Slider isFire;
    [SerializeField] Slider isReload;
    [SerializeField] Slider stamina;

    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI potionText;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI granadeText;

    // PlayerInfo playerinfo;  => 멘토링 => 리팩토링 
    // PlayerInfo.OnHPchanged += HpHudUpdate;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }

 
    
 


    public void FireHudUpdate(float fireRate) //사격 속도
    {
        isFire.value = fireRate;
    }

    public void Reload(float reload) //장전 
    {
        isReload.value = reload;
    }



    public void HpHudUpdate(int _hp)
    {
        hpText.text = $"{_hp}";
    }
    public void StaminaHudUpdate(float _stamina)
    {
        stamina.value = _stamina;
    }

    public void AddPotionUpdate(int potion)
    {
        potionText.text = $"{potion}";
    }

    public void AmmoHudUpdate(int _ammo)
    {
        ammoText.text = $"{_ammo}";
    }

    public void GranadeHudUpdate(int _granade)
    {
        granadeText.text = $"{_granade}";
    }




}
