using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLoop : MonoBehaviour {

    public GameObject CurrentRoad;
    public GameObject NextRoad;
    private GameObject parent;
    private Transform ItemParent;

    private void Start()
    {
        if (parent == null)
        {
            parent = new GameObject();
            parent.transform.position = Vector3.zero;
            parent.name = "Road";
        }

        CurrentRoad = GameSetting.Instance.objectPool.GetObject("Road01", parent.transform);
        ItemParent = CurrentRoad.transform.Find("Root");
        CreatItem(ItemParent);
        NextRoad = GameSetting.Instance.objectPool.GetObject("Road02", parent.transform);
        ItemParent = NextRoad.transform.Find("Root");
        CreatItem(ItemParent);
        NextRoad.transform.position = CurrentRoad.transform.position + new Vector3(0, 0, 160);
    }

    private void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.road)
        {
            int i = Random.Range(1, 5);
            string str = i.ToString();
            GameSetting.Instance.objectPool.ReturnObject(CurrentRoad);
            CurrentRoad = NextRoad;
            NextRoad = GameSetting.Instance.objectPool.GetObject("Road0"+str, parent.transform);
            NextRoad.transform.position = CurrentRoad.transform.position + new Vector3(0, 0, 160);
            ItemParent = NextRoad.transform.Find("Root");
            CreatItem(ItemParent);
        }
    }

    public void CreatItem(Transform parent)
    {
        Patternmanager patternmanager = Patternmanager.Instance;
        Pattern pattern = patternmanager.PatternList[Random.Range(0, patternmanager.PatternList.Count)];
        if(pattern !=null && pattern.ItemList.Count > 0)
        {
            foreach (var item in pattern.ItemList)
            {
                GameObject go = GameSetting.Instance.objectPool.GetObject(item.name,parent);
                go.transform.parent = parent;
                go.transform.localPosition = item.pos;
            }
        }
    }
}
