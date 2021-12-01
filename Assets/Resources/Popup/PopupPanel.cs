using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonsLayout = null;

    [SerializeField]
    private GameObject buttonPrefab = null;

    [SerializeField]
    private GameObject image;

    [SerializeField]
    private GameObject video;

    private float time;
    public bool openState = true;
    public float duration = 10.0f;

    public void Init()
    {
    }

    private void Update()
    {
        if (openState)
        {
            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1.0f, 1.0f, 1.0f), Time.deltaTime * duration);
            time += Time.deltaTime;
        }

        if (time > 1f)
        {
            openState = false;
        }
    }

    public void setVideo(bool _videoState)
    {
        video.SetActive(_videoState);
    }

    public void setImage(string _imageName)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("images");
        foreach (Sprite sprite in sprites)
        {
            Debug.Log(sprite.name);
            if (sprite.name == _imageName)
            {
                image.GetComponent<Image>().sprite = sprite;
            }
        }
    }
    public void setButtons(List<PopupButtonInfo> _popupButtonInfos)
    {
        foreach (var info in _popupButtonInfos)
        {
            GameObject buttonObject = Instantiate(this.buttonPrefab);
            buttonObject.transform.SetParent(this.buttonsLayout.transform, false);
            PopupButton popupButton = buttonObject.GetComponent<PopupButton>();
            popupButton.Init(info.callback, this.gameObject);
        }
    }
}