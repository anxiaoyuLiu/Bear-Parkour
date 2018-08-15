using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationController : View {

    public Animation anim;
    private Action PlayAnimation;
    private PlayerController controller;
    private GameModel gameModel;

    public override string Name
    {
        get
        {
            return Const.V_AnimationController;
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animation>();
        controller = GetComponent<PlayerController>();
        PlayAnimation = PlayRun;
        gameModel = GetModel<GameModel>();
    }

    private void Update()
    {
        if (gameModel.IsPlay && !gameModel.IsPause)
        {
            PlayAnimation();
            if (PlayAnimation != PlayRun)
            {
                GameSetting.Instance.playSound.PauseStepAudio();
            }
        }
        else
        {
            anim.Stop();
        }
    }

    public void AnimaController(InputDirection input)
    {
        switch (input)
        {
            case InputDirection.Null:
                break;
            case InputDirection.Up:
                PlayAnimation = playJump;
                break;
            case InputDirection.Down:
                PlayAnimation = playRoll;
                break;
            case InputDirection.Left:
                PlayAnimation = playLeft;
                break;
            case InputDirection.Right:
                PlayAnimation = playRight;
                break;
            default:
                break;
        }
    }

    public void PlayRun()
    {
        anim.Play(Const.run);
    }

    public void playLeft()
    {
        controller.isChanging = true;
        anim.Play(Const.left);
        if (anim[Const.left].normalizedTime > 0.9f)
        {
            PlayAnimation = PlayRun;
            controller.isChanging = false;
            GameSetting.Instance.playSound.PlayStepAudio();
        }
    }

    public void playRight()
    {
        controller.isChanging = true;
        anim.Play(Const.right);
        if (anim[Const.right].normalizedTime > 0.9f)
        {
            PlayAnimation = PlayRun;
            controller.isChanging = false;
            GameSetting.Instance.playSound.PlayStepAudio();
        }
    }

    public void playRoll()
    {
        controller.isChanging = true;
        anim.Play(Const.roll);
        if (anim[Const.roll].normalizedTime > 0.9f)
        {
            PlayAnimation = PlayRun;
            controller.isChanging = false;
            controller.isRolling = false;
            GameSetting.Instance.playSound.PlayStepAudio();
        }
    }

    public void playJump()
    {
        controller.isChanging = true;
        anim.Play(Const.jump);
        if (anim[Const.jump].normalizedTime > 0.9f)
        {
            PlayAnimation = PlayRun;
            controller.isChanging = false;
            controller.isJumping = false;
            GameSetting.Instance.playSound.PlayStepAudio();
        }
    }

    public void SendMessagePlayShoot(int num)
    {
        if (num == 0)
            PlayAnimation = PlayShoot01;
        else
            PlayAnimation = PlayShoot02;
    }

    public void PlayShoot01()
    {
        anim.Play(Const.shoot01);
        if (anim[Const.shoot01].normalizedTime > 0.9f)
        {
            PlayAnimation = PlayRun;
            GameSetting.Instance.playSound.PlayStepAudio();
        }
    }

    public void PlayShoot02()
    {
        anim.Play(Const.shoot02);
        if (anim[Const.shoot02].normalizedTime > 0.9f)
        {
            PlayAnimation = PlayRun;
            GameSetting.Instance.playSound.PlayStepAudio();
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        throw new NotImplementedException();
    }
}
