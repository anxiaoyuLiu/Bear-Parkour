using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(PlaySound))]
[RequireComponent(typeof(StaticData))]
public class GameSetting : MonoSingleton<GameSetting> {

    [HideInInspector]
    public ObjectPool objectPool;
    [HideInInspector]
    public PlaySound playSound;
    [HideInInspector]
    public StaticData staticData;

    //public GameObject[] objectList = new GameObject[30];//存储所有障碍物和奖励物品
    //GameObject go;
    //int listLength;

    //private PlayerController player;
    //GameModel gameModel;

    //private int currentscene = 0;

    private void Start()
    {
        //保留当前gameObject
        DontDestroyOnLoad(this.gameObject);

        objectPool = ObjectPool.Instance;
        playSound = PlaySound.Instance;
        staticData = StaticData.Instance;

        //gameModel = GetModel<GameModel>();

        //注册StartGameController
        RegisterController(Const.E_StartGame, typeof(StartGameController));

        SendEvent(Const.E_StartGame);

        //场景跳转
        Instance.LoadScene(1);
        //player = GameObject.FindWithTag(Tags.player).GetComponent<PlayerController>();
        //Instance.playSound.PlayBgAudio(Const.Bgm_ZhanDou);
        //Instance.playSound.StartStepAudio();

        //foreach (GameObject go in objectList)
        //{
        //    if (go != null)
        //    {
        //        listLength++;
        //    }
        //}
        //Debug.Log(listLength);
    }

    private void Update()
    {
        //Debug.Log(gameModel.IsPlay);
    }

    public void LoadScene(int level)
    {
        //加载新场景前获取当前场景信息，发送一个退出事件
        ScenesInfo scenesInfo = new ScenesInfo()
        {
            scenesIndex = SceneManager.GetActiveScene().buildIndex //赋值方法一
        };
        //scenesInfo.scenesIndex = SceneManager.GetActiveScene().buildIndex; //赋值方法二
        SendEvent(Const.E_ExitScenes, scenesInfo);

        //加载新场景
        SceneManager.LoadScene(level);
    }

    //新场景加载后，更改ScenesInfo中信息为当前场景信息，并发送进入场景事件
    private void OnLevelWasLoaded(int level)
    {
        //Debug.Log(level);
        ScenesInfo scenesInfo = new ScenesInfo()
        {
            scenesIndex = level
        };
        //scenesInfo.scenesIndex = level;
        SendEvent(Const.E_EnterScenes, scenesInfo);
    }

    private void SendEvent(string eventName, object data=null)
    {
        MVC.SendEvent(eventName, data);
    }

    private void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }

}
