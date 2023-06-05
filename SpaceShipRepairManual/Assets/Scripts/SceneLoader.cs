using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        GameScene,
        StartScene,
        DeathScene,
        EndScene
    }
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
