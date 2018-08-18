using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool> {

    public string ResourceDir = "";
    Dictionary<string, SubPool> pools = new Dictionary<string, SubPool>();

    private Transform objectParent;

    protected override void Awake()
    {
        base.Awake();
        objectParent = GameObject.Find("GameSetting").transform;
    }

    public GameObject GetObject(string name,Transform trans=null)//默认空值是为了方便object类型的创建
    {
        SubPool pool = null;
        if (!pools.ContainsKey(name))
        {
            if (trans == null)
            {
                trans = objectParent;
            }
            CreatPool(name,trans);
        }
        pool = pools[name];
        return pool.GetObject();
    }

    public void ReturnObject(GameObject go)
    {
        SubPool pool = null;
        foreach (var p in pools.Values)
        {
            if (p.ContainsThis(go))
            {
                pool = p;
                break;
            }
        }
        pool.ReturnObject(go);
    }

    //归还所有物品
    public void ReturnAll()
    {
        foreach (var p in pools.Values)
        {
            p.ReturnAll();
        }
    }

    //清空对象池（退出场景时调用）
    public void ClearPools()
    {
        pools.Clear();
    }

    private void CreatPool(string name,Transform trans)
    {
        string path = ResourceDir + "/" + name;
        GameObject go = Resources.Load<GameObject>(path);
        SubPool pool = new SubPool(go, trans);
        pools.Add(pool.Name, pool);
    }
}
