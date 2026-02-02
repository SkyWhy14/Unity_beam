using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public string SceneName;

}
