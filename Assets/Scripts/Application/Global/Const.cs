using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Const {
    
    //Event Name
    public const string E_ExitScenes = "E_ExitScenes";
    public const string E_EnterScenes = "E_EnterScenes";
    public const string E_StartGame = "E_StartGame";
    public const string E_EndGame = "E_EndGame";
    public const string E_PauseGame = "E_PauseGame";
    public const string E_ContinueGame = "E_ContinueGame";
    public const string E_PayContinueGame = "E_PayContinueGame";
    public const string E_CloseEndGame = "E_CloseEndGame";
    public const string E_BackHome = "E_BackHome";
    public const string E_GoShopping = "E_GoShopping";
    public const string E_Restart = "E_Restart";

    public const string E_UpdateDistance = "E_UpdateDistance";
    public const string E_UpdateCoin = "E_UpdateCoin";
    public const string E_UpdateScore = "E_UpdateScore";
    public const string E_UpdateGoal = "E_UpdateGoal";
    public const string E_UpdateTime = "E_UpdateTime";
    public const string E_UpdateSkill_DoubleCoin = "E_UpdateSkill_DoubleCoin";
    public const string E_UpdateSkill_SpeedUp = "E_UpdateSkill_SpeedUp";
    public const string E_UpdateSkill_Magnet = "E_UpdateSkill_Magnet";
    public const string E_BuySkill = "E_BuySkill";
    //public const string E_UpdateSkill_Shoot = "E_UpdateSkill_Shoot";

    public const string E_ReadyShoot = "E_ReadyShoot";
    public const string E_Shoot = "E_Shoot";
    public const string E_Goal = "E_Goal";
    public const string E_CreatObject = "E_CreatObject";

    //Model Name
    public const string M_GameModel = "M_GameModel";

    //View Name
    public const string V_Run = "V_Run";
    public const string V_PlayerController = "V_PlayerController";
    public const string V_AnimationController = "V_AnimationController";
    public const string V_PlayingUI = "V_PlayingUI";
    public const string V_GamePlayingUI = "V_GamePlayingUI";
    public const string V_FinalScoreUI = "V_FinalScoreUI";
    public const string V_PauseGameUI = "V_PauseGameUI";
    public const string V_GameOverUI = "V_GameOverUI";
    public const string V_ContinueGameUI = "V_ContinueGameUI";
    public const string V_BollHit = "V_BollHit";
    public const string V_SkillShopUI = "V_SkillShopUI";
    public const string V_MainMenuUI = "V_MainMenuUI";
    public const string V_ChangeLookingUI = "V_ChangeLookingUI";

    //Animation Name
    public const string run = "run";
    public const string left = "left_jump";
    public const string right = "right_jump";
    public const string jump = "jump";
    public const string roll = "roll";
    public const string fly = "fly";
    public const string shoot01 = "Shoot01";
    public const string shoot02 = "Shoot02";
    public const string standard = "standard";
    public const string flutter = "flutter";
    public const string left_flutter = "left_flutter";
    public const string right_flutter = "right_flutter";
    public const string goal_left = "QiuMen_RR";
    public const string goal_right = "QiuMen_LR";
    public const string goal_static = "QiuMen_St";

    //Object Name
    public const string Block_Ai = "Block_Ai";
    public const string Block_Ai_Yellow = "Block_Ai_Yellow";
    public const string Block_Zhong = "Block_Zhong";
    public const string Block_Zhong_Yellow = "Block_Zhong_Yellow";
    public const string Block_Gao = "Block_Gao";
    public const string Block_Gao_Yellow = "Block_Gao_Yellow";
    public const string Block_BoxBlueBig = "Block_BoxBlueBig";
    public const string Block_BoxBlueNormal = "Block_BoxBlueNormal";
    public const string Block_BoxBlueSmall = "Block_BoxBlueSmall";
    public const string Block_BoxGreenBig = "Block_BoxGreenBig";
    public const string Block_BoxGreenNormal = "Block_BoxGreenNormal";
    public const string Block_BoxGreenSmall = "Block_BoxGreenSmall";
    public const string Block_BoxRedBig = "Block_BoxRedBig";
    public const string Block_BoxRedNormal = "Block_BoxRedNormal";
    public const string Block_BoxRedSmall = "Block_BoxRedSmall";
    public const string Block_CarMove = "Block_CarMove";
    public const string Block_CarStatic = "Block_CarStatic";
    public const string Block_People = "Block_People";
    public const string Item_Goal = "Item_Goal";
    public const string Item_Coin = "Item_Coin";
    public const string Item_Stars = "Item_Stars";
    public const string Item_Magnet = "Item_Magnet";
    public const string Item_Clock = "Item_Clock";

    //Effect Name
    public const string FX_ZhuangJi = "FX_ZhuangJi";
    public const string FX_JinBi = "FX_JinBi";
    public const string FX_Goal = "FX_Goal";
    public const string Ball_fly = "Ball_fly";

    //Audio Name
    public const string Bgm_JieMian = "Bgm_JieMian";
    public const string Bgm_ZhanDou = "Bgm_ZhanDou";
    public const string Se_UI_Button = "Se_UI_Button";
    public const string Se_UI_Countdown = "Se_UI_Countdown";
    public const string Se_UI_Dress = "Se_UI_Dress";
    public const string Se_UI_End = "Se_UI_End";
    public const string Se_UI_Goal = "Se_UI_Goal";
    public const string Se_UI_Hit = "Se_UI_Hit";
    public const string Se_UI_Huadong = "Se_UI_Huadong";
    public const string Se_UI_JinBi = "Se_UI_JinBi";
    public const string Se_UI_Jump = "Se_UI_Jump";
    public const string Se_UI_Kicked = "Se_UI_Kicked";
    public const string Se_UI_LvUp = "Se_UI_LvUp";
    public const string Se_UI_Magnet = "Se_UI_Magnet";
    public const string Se_UI_Nail = "Se_UI_Nail";
    public const string Se_UI_Number = "Se_UI_Number";
    public const string Se_UI_Props = "Se_UI_Props";
    public const string Se_UI_Revival = "Se_UI_Revival";
    public const string Se_UI_Run = "Se_UI_Run";
    public const string Se_UI_Shoot = "Se_UI_Shoot";
    public const string Se_UI_Slide = "Se_UI_Slide";
    public const string Se_UI_Speed = "Se_UI_Speed";
    public const string Se_UI_Stars = "Se_UI_Stars";
    public const string Se_UI_Time = "Se_UI_Time";
    public const string Se_UI_Up = "Se_UI_Up";
    public const string Se_UI_Whist = "Se_UI_Whist";
    public const string Se_UI_Zhuang = "Se_UI_Zhuang";
}

public enum InputDirection
{
    Null,
    Up,
    Down,
    Left,
    Right
}
