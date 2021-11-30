using System.Collections.Generic;
using UnityEngine;

public class PopupBuilder
{
    private Transform target = null;
    private string title = null;
    private string description = null;
    private List<PopupButtonInfo> buttonInfoList = null;

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

        popupPanel.setTitle(this.title);
        popupPanel.setDescription(this.description);
        popupPanel.setButtons(this.buttonInfoList);

        popupPanel.Init();
    }

    public void SetTitle(string _title)
    {
        this.title = _title;
    }

    public void SetDescription(string _description)
    {
        this.description = _description;
    }

    public void SetButton(string _text, CallbackEvent _callback = null)
    {
        this.buttonInfoList.Add(new PopupButtonInfo(_text, _callback));
    }
}
