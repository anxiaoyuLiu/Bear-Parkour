using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLoop : ReusableObject {

    public GameObject CurrentRoad;
    public GameObject NextRoad;
    private GameObject parent;

    private void Start()
    {
        if (parent == null)
        {
            parent = new GameObject();
            parent.transform.position = Vector3.zero;
            parent.name = "Road";
        }

        CurrentRoad = GameSetting.Instance.objectPool.GetObject("Road01", parent.transform);
        NextRoad = GameSetting.Instance.objectPool.GetObject("Road02", parent.transform);
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
        }
    }

    public override void SetInfo()
    {
        
    }

    public override void ClearInfo()
    {
        
    }
}
