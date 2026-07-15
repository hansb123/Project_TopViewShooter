using UnityEngine.UI;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;


    [SerializeField] Slider isFire;
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


    public void FireHudUpdate(float fireRate)
    {
        isFire.value = fireRate;
    }




}
