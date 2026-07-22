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

    [SerializeField] TextMeshProUGUI helmetText;
    [SerializeField] TextMeshProUGUI chestText;
    [SerializeField] TextMeshProUGUI legText;

  //  [SerializeField] TextMeshProUGUI nowDefenceText;


    [SerializeField] GameObject itemGetText;

 


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


    private void Start()
    {
        itemGetText.SetActive(false);
    }



    public void FireHudUpdate(float fireRate) //사격 속도
    {
        isFire.value = fireRate;
    }

    public void Reload(float reload) //장전 
    {
        isReload.value = reload;
    }



    public void HpHudUpdate(float _hp) //Hp갱신 
    {
        hpText.text = $"{_hp}";
    }

    public void StaminaHudUpdate(float _stamina) //스테미너 게이지 
    {
        stamina.value = _stamina;
    }

    public void AddPotionUpdate(int potion) //포션 개수 관리 
    {
        potionText.text = $"{potion}";
    }

    public void AmmoHudUpdate(int _ammo) //탄약 관리 
    {
        ammoText.text = $"{_ammo}";
    }

    public void GranadeHudUpdate(int _granade) //TODO : 폭탄 개수 => 추후 스테미너 포션으로 변경 예정 
    {
        granadeText.text = $"{_granade}";
    }

    public void EquipText(int helmet, int chest, int leg)
    {
        helmetText.text = $"{helmet}";

        chestText.text = $"{chest}";

        legText.text = $"{leg}";

       //nowDefenceText.text = $"{helmet + chest + leg}";
    }


    public void GetItemText() //아이템 (상호작용) => 인터페이스로 리팩토링 진행 예정 
    {
        itemGetText.SetActive(true);
    }

    public void HideItemText() //아이템 (상호작용) => 인터페이스로 리팩토링 진행 예정
    {
        itemGetText.SetActive(false);
    }

   

    public void MonsterHpUi()
    {

    }



}
