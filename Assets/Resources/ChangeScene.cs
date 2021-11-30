using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private RaycastHit hit;
    private bool moveSceneReady;
    private bool zoomOut;
    private string hitName;
    
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
                hitName = hit.collider.name;
                Debug.Log(hitName);
                zoomOut = true;
            }
        }

        if(zoomOut)
        {
            camCon.zoomCamera(20.0f);
            moveSceneReady = Camera.main.fieldOfView <= 45.0f;
        }

        if (moveSceneReady)
        {
            switch (hitName)
            {
                case "MoveCafeObject":
                    changeScene("CafeScene");
                    break;
                case "MoveLobbyObject":
                    changeScene("LobbyScene");
                    break;
                case "MoveChildObject":
                    changeScene("ChildScene");
                    break;
                case "MoveMainObject":
                    changeScene("MainScene");
                    break;
            }
        }
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}