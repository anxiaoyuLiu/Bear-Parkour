using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPool { // : MonoBehaviour（继承MonoBehaviour会导致Worning，暂且取消）

    List<GameObject> PoolList = new List<GameObject>();
    GameObject m_prefab;
    Transform m_parent;

    public string Name
    {
        get { return m_prefab.name; }
    }

    public SubPool (GameObject go,Transform parent)
    {
        m_prefab = go;
        m_parent = parent;
    }

    //取出池中可用的对象
    public GameObject GetObject()
    {
        GameObject go = null;
        foreach (GameObject obj in PoolList)
        {
            if (obj.activeSelf == false)
            {
                go = obj;
            }
        }
        if (go == null)
        {
            go = GameObject.Instantiate(m_prefab);
            go.transform.parent = m_parent;
            PoolList.Add(go);
        }
        go.SetActive(true);
        //go.SendMessage("SetInfo", SendMessageOptions.DontRequireReceiver);
        //Debug.Log("send message to:"+go.name);
        go.SendMessage("SetInfo",SendMessageOptions.DontRequireReceiver);
        return go;
    }

    //将一个对象归池
    public void ReturnObject(GameObject go)
    {
        if (ContainsThis(go))
        {
            go.SendMessage("ClearInfo", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    //将所有显示的对象归池
    public void ReturnAll()
    {
        foreach (GameObject obj in PoolList)
        {
            if (obj.activeSelf)
            {
                ReturnObject(obj);
            }
        }
    }

    public bool ContainsThis(GameObject go)
    {
        return PoolList.Contains(go);
    }
}
