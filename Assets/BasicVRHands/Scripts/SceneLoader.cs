using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string currentDemoScene = null; // храним имя текущей загруженной демо-сцены

    // Загружает новую демо-сцену, выгружая предыдущую
    public void LoadDemoScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning("Имя сцены не указано!");
            return;
        }

        // Если уже загружена какая-то демо-сцена, выгружаем её
        if (!string.IsNullOrEmpty(currentDemoScene))
        {
            SceneManager.UnloadSceneAsync(currentDemoScene);
            Debug.Log($"Выгружена предыдущая сцена: {currentDemoScene}");
        }

        // Загружаем новую сцену аддитивно
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        currentDemoScene = sceneName;
        Debug.Log($"Загружена новая сцена: {sceneName}");
    }

    // Метод для возврата в HubScene (выгружает текущую демо-сцену, но HubScene остаётся)
    public void UnloadCurrentDemoScene()
    {
        if (!string.IsNullOrEmpty(currentDemoScene))
        {
            SceneManager.UnloadSceneAsync(currentDemoScene);
            currentDemoScene = null;
            Debug.Log("Демо-сцена выгружена, возврат в HubScene");
        }
    }

    // Выход из приложения
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}