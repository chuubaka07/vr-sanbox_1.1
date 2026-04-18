using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Необходимо для работы с UI

public class SceneLoader : MonoBehaviour
{
    // Этот метод будет вызываться при нажатии на кнопку
    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            Debug.Log($"Загружаем сцену: {sceneName}");
        }
        else
        {
            Debug.LogWarning("Имя сцены не указано!");
        }
    }

    // Метод для выгрузки сцены (например, при нажатии кнопки "Назад" в демо-сцене)
    public void UnloadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
            Debug.Log($"Выгружаем сцену: {sceneName}");
        }
    }

    // Метод для выхода из приложения
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}