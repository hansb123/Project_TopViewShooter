using UnityEngine;

public class MonsterDestroyWall : MonoBehaviour
{
    [SerializeField] Monster[] monsters;

    bool clear;
    //해당 방안에 몬스터가 전부 죽으면 해당 문 파괴 



    private void Update()
    {
        bool clear = true;

        foreach (Monster monster in monsters)
        {
            if (monster != null)
            {
                clear = false;
                break;
            }
        }

        if (clear)
        {
            Destroy(gameObject);
        }
    }


}


