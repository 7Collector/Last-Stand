using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSc : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
