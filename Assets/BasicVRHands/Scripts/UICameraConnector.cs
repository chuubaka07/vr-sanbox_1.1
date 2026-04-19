using UnityEngine;

public class UICameraConnector : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            canvas.worldCamera = mainCam;
            Debug.Log("Canvas привязан к Main Camera");
        }
        else
        {
            Debug.LogError("Main Camera не найдена!");
        }
    }
}