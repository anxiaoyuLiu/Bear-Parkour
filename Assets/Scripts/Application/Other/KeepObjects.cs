using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepObjects : MonoBehaviour {
    
	void Start () {
        //保留当前gameObject
        DontDestroyOnLoad(this.gameObject);
    }

}
