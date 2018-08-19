using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : Controller {

    public override void Execute(object data)
    {
        //注册所有controller
        RegisterController(Const.E_EnterScenes, typeof(EnterScenesController));
        RegisterController(Const.E_ExitScenes, typeof(ExitScenesController));
        RegisterController(Const.E_EndGame, typeof(EndGameController));
        RegisterController(Const.E_PauseGame, typeof(PauseGameController));
        RegisterController(Const.E_ContinueGame, typeof(ContinulGameController));
        RegisterController(Const.E_UpdateSkill_DoubleCoin, typeof(DoubleCoinController));
        RegisterController(Const.E_UpdateSkill_SpeedUp, typeof(SpeedUpController));
        RegisterController(Const.E_UpdateSkill_Magnet, typeof(MagnetController));
        RegisterController(Const.E_Shoot, typeof(ShootController));
        RegisterController(Const.E_Goal, typeof(GoalController));
        RegisterController(Const.E_CreatObject, typeof(CreatObjectController));
        RegisterController(Const.E_PayContinueGame, typeof(PayContinueGameController));
        RegisterController(Const.E_CloseEndGame, typeof(CloseEndGameController));
        RegisterController(Const.E_BackHome, typeof(BackHomeController));
        RegisterController(Const.E_GoShopping, typeof(GoShoppingController));
        RegisterController(Const.E_Restart, typeof(RestartController));
        RegisterController(Const.E_BuySkill, typeof(BuySkillController));
        RegisterController(Const.E_TimeUp, typeof(TimeUpController));
        //注册model
        RegisterModel(new GameModel());
        //初始化
    }
}
