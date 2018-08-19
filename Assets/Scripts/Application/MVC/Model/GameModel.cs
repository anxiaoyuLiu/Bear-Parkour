using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : Model {

    //角色外观信息
    private int footballIndex = 0;
    private int playerIndex = 0;
    private int clothesIndex = 0;

    //状态
    private bool isPlay = true;
    private bool isPause = false;
    private bool isOver = false;
    private bool isDoubleCoin = false;
    private bool isMagnet = false;
    private bool isSpeedUp = false;
    private bool isBallFlying = false;

    //技能时间
    private int starsTime = 8;
    private int speedUpTime = 10;
    private int magnetTime = 12;
    private int addTime = 1;

    //游戏时长
    private float times = 90;

    //角色全局数据（全局数据只在第一次进行游戏时进行初始化）
    private int coin_Total = 5000;
    private int lv = 0;
    private int exp = 0;
    private int exp_Up = 500;
    private int speedUpSkillCount = 3;
    private int doubleCoinSkillCount = 3;
    private int magnetSkillCount = 3;
    private float speed = 15;
    private float maxSpeed = 50;

    //单局游戏数据（单局数据每一次进行游戏时都进行初始化）
    private int distance = 0;
    private int score = 0;
    private int coin = 0;
    private int goal = 0;
    private int payCoin = 500;
    private float targetSpeed = 15;

    public override string Name
    {
        get
        {
            return Const.M_GameModel;
        }
    }

    public bool IsPause
    {
        get
        {
            return isPause;
        }

        set
        {
            isPause = value;
        }
    }

    public bool IsPlay
    {
        get
        {
            return isPlay;
        }

        set
        {
            isPlay = value;
        }
    }

    public int StarsTime
    {
        get
        {
            return starsTime;
        }

        set
        {
            starsTime = value;
        }
    }

    public int LodestoneTime
    {
        get
        {
            return MagnetTime;
        }

        set
        {
            MagnetTime = value;
        }
    }

    public int MagnetTime
    {
        get
        {
            return magnetTime;
        }

        set
        {
            magnetTime = value;
        }
    }

    public int AddTime
    {
        get
        {
            return addTime;
        }

        set
        {
            addTime = value;
        }
    }

    public int Distance
    {
        get
        {
            return distance;
        }

        set
        {
            distance = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public int Coin
    {
        get
        {
            return coin;
        }

        set
        {
            coin = value;
        }
    }

    public int Goal
    {
        get
        {
            return goal;
        }

        set
        {
            goal = value;
        }
    }

    public float Times
    {
        get
        {
            return times;
        }

        set
        {
            times = value;
        }
    }

    public int SpeedUpSkillCount
    {
        get
        {
            return speedUpSkillCount;
        }

        set
        {
            speedUpSkillCount = value;
        }
    }

    public int MagnetSkillCount
    {
        get
        {
            return magnetSkillCount;
        }

        set
        {
            magnetSkillCount = value;
        }
    }

    public bool IsDoubleCoin
    {
        get
        {
            return isDoubleCoin;
        }

        set
        {
            isDoubleCoin = value;
        }
    }

    public bool IsMagnet
    {
        get
        {
            return isMagnet;
        }

        set
        {
            isMagnet = value;
        }
    }

    public bool IsSpeedUp
    {
        get
        {
            return isSpeedUp;
        }

        set
        {
            isSpeedUp = value;
        }
    }

    public int DoubleCoinSkillCount
    {
        get
        {
            return doubleCoinSkillCount;
        }

        set
        {
            doubleCoinSkillCount = value;
        }
    }

    public int SpeedUpTime
    {
        get
        {
            return speedUpTime;
        }

        set
        {
            speedUpTime = value;
        }
    }

    public float MaxSpeed
    {
        get
        {
            return maxSpeed;
        }

        set
        {
            maxSpeed = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
            if (speed > maxSpeed)
                speed = maxSpeed;
        }
    }

    public int PayCoin
    {
        get
        {
            return payCoin;
        }

        set
        {
            payCoin = value;
        }
    }

    public int Coin_Total
    {
        get
        {
            return coin_Total;
        }

        set
        {
            coin_Total = value;
        }
    }

    public int Lv
    {
        get
        {
            return lv;
        }

        set
        {
            lv = value;
        }
    }

    public int Exp
    {
        get
        {
            return exp;
        }

        set
        {
            exp = value;
        }
    }

    public int Exp_Up
    {
        get
        {
            return exp_Up;
        }

        set
        {
            exp_Up = value;
        }
    }

    public float TargetSpeed
    {
        get
        {
            return targetSpeed;
        }

        set
        {
            targetSpeed = value;
        }
    }

    public bool IsOver
    {
        get
        {
            return isOver;
        }

        set
        {
            isOver = value;
        }
    }

    public int FootballIndex
    {
        get
        {
            return footballIndex;
        }

        set
        {
            footballIndex = value;
        }
    }

    public int PlayerIndex
    {
        get
        {
            return playerIndex;
        }

        set
        {
            playerIndex = value;
        }
    }

    public int ClothesIndex
    {
        get
        {
            return clothesIndex;
        }

        set
        {
            clothesIndex = value;
        }
    }

    public bool IsBallFlying
    {
        get
        {
            return isBallFlying;
        }

        set
        {
            isBallFlying = value;
        }
    }
}
