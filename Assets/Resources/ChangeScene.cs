using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private string clickedButtonName;
    private bool moveSceneReady = false;
    private bool zoomOut = false;

    private readonly CameraControl camCon = new CameraControl();

    void Update()
    {
        if (zoomOut)
        {
            StartCoroutine(camCon.ZoomCamera(20.0f));
            moveSceneReady = Camera.main.fieldOfView <= 45.0f;
        }

        if (moveSceneReady && clickedButtonName != null)
        {
            switch (clickedButtonName)
            {
                case "MoveCafeButton":
                    LoadScene("CafeScene");
                    break;
                case "MoveLobbyButton":
                    LoadScene("LobbyScene");
                    break;
                case "MoveChildButton":
                    LoadScene("ChildScene");
                    break;
                case "MoveMainButton":
                    LoadScene("MainScene");
                    break;
            }
        }
    }

    public void OnButtonClick()
    {
        clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        zoomOut = true;
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}