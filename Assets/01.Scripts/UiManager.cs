using JetBrains.Annotations;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

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


    public void FireUpdate(float fireRate)
    {

    }

}
