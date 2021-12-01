using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBuilder
{
    private Transform target = null;
    private string imageName = null;
    private List<PopupButtonInfo> buttonInfoList = null;
    private bool videoEnabled = false;


    public PopupBuilder(Transform _target)
    {
        this.target = _target;
        this.buttonInfoList = new List<PopupButtonInfo>();
    }

    public void Build()
    {
        GameObject popupObject = GameObject.Instantiate(Resources.Load("Popup/" + "PopupPanel", typeof(GameObject))) as GameObject;
        popupObject.transform.SetParent(this.target, false);

        PopupPanel popupPanel = popupObject.GetComponent<PopupPanel>();

        popupPanel.setImage(this.imageName);
        popupPanel.setButtons(this.buttonInfoList);
        popupPanel.setVideo(this.videoEnabled);

        popupPanel.Init();
    }

    public void setVideo()
    {
        this.videoEnabled = true;
    }

    public void SetImage(string _imageName)
    {
        this.imageName = _imageName;
    }

    public void SetButton(CallbackEvent _callback = null)
    {
        this.buttonInfoList.Add(new PopupButtonInfo(_callback));
    }
}
