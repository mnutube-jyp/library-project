using System.Collections;
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
        this.gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
    }

    private void Update()
    {
        StartCoroutine(ZoomPopup(new Vector3(1.0f, 1.0f, 1.0f)));

    }

    IEnumerator ZoomPopup(Vector3 chagedValue)
    {
        if (openState)
        {
            this.gameObject.transform.localScale = Vector3.Lerp(transform.localScale, chagedValue, Time.deltaTime * duration);
            time += Time.deltaTime;
        }

        if (time > 1f)
        {
            openState = false;
        }

        yield return new WaitForSeconds(.1f);
    }

    public void SetVideo(bool _videoState)
    {
        video.SetActive(_videoState);
    }

    public void SetImage(string _imageName)
    {
        Sprite sprite = Resources.Load<Sprite>("images/" + _imageName);
        image.GetComponent<Image>().sprite = sprite;
    }
    public void SetButtons(List<PopupButtonInfo> _popupButtonInfos)
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