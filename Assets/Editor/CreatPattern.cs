using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreatPattern : EditorWindow {

    [MenuItem("PersonalTools/ClickToAddPattern")]

	static void ClickToAddPattern()
    {
        GameObject PatternObj = GameObject.Find("PatternManager");
        if(PatternObj != null)
        {
            Patternmanager patternmanager = PatternObj.GetComponent<Patternmanager>();
            if (Selection.gameObjects.Length == 1)
            {
                Transform currenChild = Selection.gameObjects[0].transform.Find("Root");
                if(currenChild != null)
                {
                    Pattern pattern = new Pattern();
                    foreach (Transform child in currenChild)
                    {
                        var prefab = UnityEditor.PrefabUtility.GetPrefabParent(child.gameObject);
                        if(prefab != null)
                        {
                            PrefabItem prefabItem = new PrefabItem
                            {
                                name = prefab.name,
                                pos = child.localPosition
                            };
                            pattern.ItemList.Add(prefabItem);
                        }
                    }
                    patternmanager.PatternList.Add(pattern);
                }
            }
        }
    }
}
