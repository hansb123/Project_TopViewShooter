using UnityEngine.UI;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;


    [SerializeField] Slider isFire;
    [SerializeField] Slider isReload;
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



    public void HpHudUpdate(float _Hp)
    {

    }

    public void AmmoHudUpdate(int _Ammo)
    {

    }

    public void GranadeHudUpdate(int _granade)
    {

    }




}
