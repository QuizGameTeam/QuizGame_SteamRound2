using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Test", LoadSceneMode.Single);
    }
}
