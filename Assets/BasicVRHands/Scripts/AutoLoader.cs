using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoader : MonoBehaviour
{
    void Start()
    {
        // Загружаем HubScene аддитивно
        SceneManager.LoadSceneAsync("HubScene", LoadSceneMode.Additive);
    }
}