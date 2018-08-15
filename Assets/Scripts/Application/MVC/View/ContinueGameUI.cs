using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueGameUI : View {

    public Image ShowImage;
    public Sprite[] numberTexture;

    private bool start = true;

    public override string Name
    {
        get
        {
            return Const.V_ContinueGameUI;
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show(string controller)
    {
        gameObject.SetActive(true);
        switch (controller)
        {
            case "continue":
                StartCoroutine(IChangeNumber_free());
                break;
            case "payContinue":
                StartCoroutine(IChangeNumber_pay());
                break;
            default:
                break;
        }
    }

    IEnumerator IChangeNumber_free()
    {
        int time = 3;
        AudioSource audioSource = GameSetting.Instance.playSound.audio_effect;
        audioSource.pitch = 0.7f;
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Countdown);
        while (time > 0)
        {
            time--;
            ShowImage.sprite = numberTexture[time];
            yield return new WaitForSeconds(1);
        }
        Hide();
        audioSource.pitch = 1;
        SendEvent(Const.E_ContinueGame, start);
    }

    IEnumerator IChangeNumber_pay()
    {
        int time = 3;
        AudioSource audioSource = GameSetting.Instance.playSound.audio_effect;
        audioSource.pitch = 0.7f;
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Countdown);
        while (time > 0)
        {
            time--;
            ShowImage.sprite = numberTexture[time];
            yield return new WaitForSeconds(1);
        }
        Hide();
        audioSource.pitch = 1;
        SendEvent(Const.E_PayContinueGame, start);
    }

    public override void HandleEvent(string eventName, object data)
    {
        throw new System.NotImplementedException();
    }
}
