using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    private RaycastHit hit;
    private bool moveSceneReady;
    private bool zoomOut;
    private string clickedButtonName;
    
    private readonly CameraControl camCon = new CameraControl();

    void Start()
    {
        zoomOut = false;
        moveSceneReady = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                clickedButtonName = hit.collider.name;
                Debug.Log(clickedButtonName);
                zoomOut = true;
            }
        }

        if(zoomOut)
        {
            camCon.zoomCamera(20.0f);
            moveSceneReady = Camera.main.fieldOfView <= 45.0f;
        }

        if (moveSceneReady && clickedButtonName != null)
        {
            switch (clickedButtonName)
            {
                case "MoveCafeButton":
                    changeScene("CafeScene");
                    break;
                case "MoveLobbyButton":
                    changeScene("LobbyScene");
                    break;
                case "MoveChildButton":
                    changeScene("ChildScene");
                    break;
                case "MoveMainButton":
                    changeScene("MainScene");
                    break;
            }
        }
    }

    public void onButtonClick ()
    {
        clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        zoomOut = true;
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}