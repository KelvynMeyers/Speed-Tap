using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    //// PUBLIC FUNCTIONS

    // Simple function utilized by all transition buttons to move to a specified scene
    public void SwitchScene(string SceneName)
    {
        AudioManager.instance.Play("ButtonClick");
        SceneManager.LoadScene(SceneName);
    }
}
