using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;


    [SerializeField] Slider isFire;
    [SerializeField] Slider isReload;

    [SerializeField] TextMeshProUGUI ammoText;

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

    private void Update()
    {
        
    }


    public void FireHudUpdate(float fireRate) //사격 속도
    {
        isFire.value = fireRate;
    }

    public void Reload(float reload) //장전 
    {
        isReload.value = reload;
    }



    public void HpHudUpdate(float _hp)
    {

    }

    public void AmmoHudUpdate(int _ammo)
    {
        ammoText.text = $"{_ammo}";
    }

    public void GranadeHudUpdate(int _granade)
    {

    }




}
