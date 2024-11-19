using UnityEngine;
using UnityEngine.SceneManagement;


public class SwitchScenes : MonoBehaviour
{
    public string NextScene;
    public void OnButtonClick()
    {
        Debug.Log("Button clicked!");
        SceneManager.LoadScene(NextScene);
    }
}
