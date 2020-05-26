using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
