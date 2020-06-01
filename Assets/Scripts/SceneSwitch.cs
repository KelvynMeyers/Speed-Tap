using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(string SceneName)
    {
        AudioManager.instance.Play("ButtonClick");
        SceneManager.LoadScene(SceneName);
    }
}
