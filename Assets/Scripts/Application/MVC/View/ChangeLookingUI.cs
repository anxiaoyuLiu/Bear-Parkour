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

    GameModel gameModel;
    //public Dictionary<int, Dictionary<int, Material>> platerMaterial = new Dictionary<int, Dictionary<int, Material>>();

    //private int playerIndex = 0;
    //private int clothesIndex = 0;
    public Text coinText;

    private void Start()
    {
        UpdateCoin();
    }

    public override string Name
    {
        get
        {
            return Const.V_ChangeLookingUI;
        }
    }

    private void Awake()
    {
        gameModel = GetModel<GameModel>();
    }

    //更换足球皮肤
    public void ChooseFootball1()
    {
        gameModel.FootballIndex = 0;
        footballMesh.material = footballMaterial[0];
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void ChooseFootball2()
    {
        gameModel.FootballIndex = 1;
        footballMesh.material = footballMaterial[1];
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void ChooseFootball3()
    {
        gameModel.FootballIndex = 2;
        footballMesh.material = footballMaterial[2];
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void ChooseFootball4()
    {
        gameModel.FootballIndex = 3;
        footballMesh.material = footballMaterial[3];
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    //更换角色
    public void ChoosePlayer1()
    {
        gameModel.PlayerIndex = 0;
        playerHead.sprite = HeadSprite[0];
        ChangePlayerLooking();
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void ChoosePlayer2()
    {
        gameModel.PlayerIndex = 1;
        playerHead.sprite = HeadSprite[1];
        ChangePlayerLooking();
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void ChoosePlayer3()
    {
        gameModel.PlayerIndex = 2;
        playerHead.sprite = HeadSprite[2];
        ChangePlayerLooking();
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    //更换衣服
    public void ChooseClothes1()
    {
        gameModel.ClothesIndex = 0;
        ChangePlayerLooking();
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    public void ChooseClothes2()
    {
        gameModel.ClothesIndex = 1;
        ChangePlayerLooking();
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }
    public void ChooseClothes3()
    {
        gameModel.ClothesIndex = 2;
        ChangePlayerLooking();
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }
    public void ChooseClothes4()
    {
        gameModel.ClothesIndex = 3;
        ChangePlayerLooking();
        GameSetting.Instance.playSound.PlayEffectAudio(Const.Se_UI_Button);
    }

    //改变角色外观
    private void ChangePlayerLooking()
    {
        switch (gameModel.PlayerIndex)
        {
            case 0:
                switch (gameModel.ClothesIndex)
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
                switch (gameModel.ClothesIndex)
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
                switch (gameModel.ClothesIndex)
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

    public void UpdateCoin()
    {
        coinText.text = gameModel.Coin_Total.ToString();
    }

    public override void RegisterEventList()
    {
        base.RegisterEventList();
        eventList.Add(Const.E_UpdateCoin);
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Const.E_UpdateCoin:
                UpdateCoin();
                break;
            default:
                break;
        }
    }

}
