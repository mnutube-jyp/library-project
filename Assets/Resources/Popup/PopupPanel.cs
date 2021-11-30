using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupPanel : MonoBehaviour
{
    [SerializeField]
    private Text titleText = null;

    [SerializeField]
    private Text descriptionText = null;

    [SerializeField]
    private GameObject buttonsLayout = null;

    [SerializeField]
    private GameObject buttonPrefab = null;

    private float time;
    public bool openState = true;

    public void Init()
    {
    }

    private void Update()
    {
        if(openState)
        {
            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.0f, 1.0f, 1.0f), Time.deltaTime * 10.0f);
            time += Time.deltaTime;
        }

        if(time > 1f)
        {
            openState = false;
        }
    }

    public void setTitle(string _title)
    {
        this.titleText.text = _title;
    }

    public void setDescription(string _description)
    {
        this.descriptionText.text = _description;
    }

    public void setButtons(List<PopupButtonInfo> _popupButtonInfos)
    {
        foreach (var info in _popupButtonInfos)
        {
            GameObject buttonObject = Instantiate(this.buttonPrefab);
            buttonObject.transform.SetParent(this.buttonsLayout.transform, false);
            PopupButton popupButton = buttonObject.GetComponent<PopupButton>();
            popupButton.Init(info.text, info.callback, this.gameObject);
        }
    }
}