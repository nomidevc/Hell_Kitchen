using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public enum Scene
    {
        MainMenuScene,
        GameScene,
        LoadingScene
    }
    
    private static Scene m_targetScene;
    
    public static void Load(Scene sceneToLoad)
    {
        Loader.m_targetScene = sceneToLoad;
        SceneManager.LoadScene(nameof(Scene.LoadingScene));
        
    }
    
    public static void LoadTargetScene()
    {
        SceneManager.LoadScene(Loader.m_targetScene.ToString());
    }
}
