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

    public GameObject[] objectList = new GameObject[30];//存储所有障碍物和奖励物品
    GameObject go;
    int listLength;

    //private PlayerController player;
    //GameModel gameModel;

    private int currentscene = 0;

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
        Instance.LoadScene(4);
        //player = GameObject.FindWithTag(Tags.player).GetComponent<PlayerController>();
        Instance.playSound.PlayBgAudio(Const.Bgm_ZhanDou);
        Instance.playSound.StartStepAudio();

        //通知CreatObjectController类开始创建游戏物品
        currentscene = SceneManager.GetActiveScene().buildIndex;
        if (currentscene == 4)
        {
            StartCoroutine(ICreatObject());
        }

        foreach (GameObject go in objectList)
        {
            if (go != null)
            {
                listLength++;
            }
        }
        //Debug.Log(listLength);
    }

    private void Update()
    {
        //Debug.Log(gameModel.IsPlay);
    }

    public void LoadScene(int level)
    {
        ScenesInfo scenesInfo = new ScenesInfo()
        {
            scenesIndex = SceneManager.GetActiveScene().buildIndex
        };
        //scenesInfo.scenesIndex = SceneManager.GetActiveScene().buildIndex;

        SendEvent(Const.E_ExitScenes, scenesInfo);
        SceneManager.LoadScene(level);
    }

    private void OnLevelWasLoaded(int level)
    {
        //通知CreatObjectController类开始创建游戏物品
        if (level == 4)
        {

            StartCoroutine(ICreatObject());
        }

        ScenesInfo scenesInfo = new ScenesInfo()
        {
            scenesIndex = level
        };
        //scenesInfo.scenesIndex = level;
        SendEvent(Const.E_EnterScenes, scenesInfo);
    }

    IEnumerator ICreatObject()
    {
        while (true)//暂时取消物品自动生成
        {
            //if (player.isPlay&&!player.isPause)
            {
                int num = UnityEngine.Random.Range(0, 30);
                if (num >= listLength)
                {
                    num = listLength - 1;
                }
                //Debug.Log(num);
                go = objectList[num];
                SendEvent(Const.E_CreatObject, go.name);
                yield return new WaitForSeconds(1);
            }
        }
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
