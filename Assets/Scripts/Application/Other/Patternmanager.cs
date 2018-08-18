using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Patternmanager : MonoSingleton<Patternmanager> {
    
    //方案列表
    public List<Pattern> PatternList = new List<Pattern>();

}

//一个物体对象
[Serializable]
public class PrefabItem
{
    public string name;
    public Vector3 pos;
}

//一套方案（存储一套方案所需的所有物品对象）
[Serializable]
public class Pattern
{
    public List<PrefabItem> ItemList = new List<PrefabItem>();
}

