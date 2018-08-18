using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLookingUI : View {

    public MeshRenderer footballMesh;
    public SkinnedMeshRenderer playerMesh;
    public Material[] footballMaterial;
    public Material[] player1Material;
    public Material[] player2Material;
    public Material[] player3Material;
    public Image playerHead;
    public Sprite[] HeadSprite;
    //public Dictionary<int, Dictionary<int, Material>> platerMaterial = new Dictionary<int, Dictionary<int, Material>>();

    private int playerIndex = 0;
    private int clothesIndex = 0;

    public override string Name
    {
        get
        {
            return Const.V_ChangeLookingUI;
        }
    }

    //更换足球皮肤
    public void ChooseFootball1()
    {
        footballMesh.material = footballMaterial[0];
    }

    public void ChooseFootball2()
    {
        footballMesh.material = footballMaterial[1];
    }

    public void ChooseFootball3()
    {
        footballMesh.material = footballMaterial[2];
    }

    public void ChooseFootball4()
    {
        footballMesh.material = footballMaterial[3];
    }

    //更换角色
    public void ChoosePlayer1()
    {
        playerIndex = 0;
        playerHead.sprite = HeadSprite[0];
        ChangePlayerLooking();
    }

    public void ChoosePlayer2()
    {
        playerIndex = 1;
        playerHead.sprite = HeadSprite[1];
        ChangePlayerLooking();
    }

    public void ChoosePlayer3()
    {
        playerIndex = 2;
        playerHead.sprite = HeadSprite[2];
        ChangePlayerLooking();
    }

    //更换衣服
    public void ChooseClothes1()
    {
        clothesIndex = 0;
        ChangePlayerLooking();
    }

    public void ChooseClothes2()
    {
        clothesIndex = 1;
        ChangePlayerLooking();
    }
    public void ChooseClothes3()
    {
        clothesIndex = 2;
        ChangePlayerLooking();
    }
    public void ChooseClothes4()
    {
        clothesIndex = 3;
        ChangePlayerLooking();
    }

    //改变角色外观
    private void ChangePlayerLooking()
    {
        switch (playerIndex)
        {
            case 0:
                switch (clothesIndex)
                {
                    case 0:
                        playerMesh.material = player1Material[0];
                        break;
                    case 1:
                        playerMesh.material = player1Material[1];
                        break;
                    case 2:
                        playerMesh.material = player1Material[2];
                        break;
                    case 3:
                        playerMesh.material = player1Material[3];
                        break;
                    default:
                        break;
                }
                break;
            case 1:
                switch (clothesIndex)
                {
                    case 0:
                        playerMesh.material = player2Material[0];
                        break;
                    case 1:
                        playerMesh.material = player2Material[1];
                        break;
                    case 2:
                        playerMesh.material = player2Material[2];
                        break;
                    case 3:
                        playerMesh.material = player2Material[3];
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch (clothesIndex)
                {
                    case 0:
                        playerMesh.material = player3Material[0];
                        break;
                    case 1:
                        playerMesh.material = player3Material[1];
                        break;
                    case 2:
                        playerMesh.material = player3Material[2];
                        break;
                    case 3:
                        playerMesh.material = player3Material[3];
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }

    public void ShopButtonClick()
    {
        GameSetting.Instance.LoadScene(3);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void HomeButtonClick()
    {
        GameSetting.Instance.LoadScene(1);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void StartGameButtonClick()
    {
        GameSetting.Instance.LoadScene(4);
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

}
