using UnityEngine;
using UnityEngine.UI;

public class MonsterHpbar : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void UpdateHp(float value)
    {
        slider.value = value;
    }

   
}
