using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    //몬스터들을 일제히 소환
    // = > Epic 몬스터 3, 근접, 원거리 몬스터 3 (Rare) 
    //소환 
    [SerializeField] Transform[] spawnPoint;
    [SerializeField] GameObject[] monsters;




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Spawn();
        }
    }



    private void Spawn()
    {
        for (int i = 0; i < monsters.Length; i++ )
        {
            Instantiate(monsters[i], spawnPoint[i].position, Quaternion.identity);
        }

        Destroy(gameObject);
       
    }
}
