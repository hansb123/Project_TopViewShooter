using System.Collections.Generic;
using UnityEngine;
//public enum PoolType
//{
//    Arrow,
//    Bullet
//}

//enum{ }//
//TODO : 시간남으면 구현..


public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    [SerializeField] List<GameObject> objList = new();
    [SerializeField] int poolsize;
    Dictionary<string, Queue<GameObject>> pools = new();


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


    void Start()
    {
        foreach(GameObject obj in objList)
        {
            pools[obj.name] = new Queue<GameObject>();

            GameObject parentPool = new($"{obj.name}_Pool");
            parentPool.transform.SetParent(this.transform);

            for(int i = 0; i < poolsize; i++)
            {
                GameObject ori = Instantiate(obj, parentPool.transform);
                ori.SetActive(false);
                pools[obj.name].Enqueue(ori);

            }
        
        }
        
    }


    public T GetObject<T>(string name) where T : Component
    {
        //예외처리
        if(!pools.ContainsKey(name))
        {
            return null;
        }

        if (pools[name].Count > 0)
        {
            GameObject ori = pools[name].Dequeue();
            ori.SetActive(true);

            return ori.GetComponent<T>();
        }
        else
        {
            GameObject ori = Instantiate(objList.Find(obj => obj.name == name));

            return ori.GetComponent<T>();

        }
   
    }

    public void ReturnObject(string name,GameObject ori)
    {
        if(!pools.ContainsKey(name))
        {
            Destroy(ori);
            return;
        }

        ori.SetActive(false);
        pools[name].Enqueue(ori);
    }

}
