using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : View {

    public override string Name
    {
        get
        {
            return Const.V_MainMenuUI;
        }
    }

    public void ShopButtonClick()
    {
        GameSetting.Instance.LoadScene(3);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void SettingButtonClick()
    {
        GameSetting.Instance.LoadScene(2);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void StartGameButtonClick()
    {
        GameSetting.Instance.LoadScene(4);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void QuitGameButtonClick()
    {
        Application.Quit();
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

}
