using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTitle : MonoBehaviour
{
    public void ReturnTitle()
    {
        SceneManager.LoadScene("Test", LoadSceneMode.Single);
    }
}
