using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : Controller {

    public override void Execute(object data)
    {
        SceneManager.LoadScene(4);
    }

}
