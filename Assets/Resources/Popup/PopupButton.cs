using UnityEngine;
using UnityEngine.UI;

public class PopupButton : MonoBehaviour
{
    [SerializeField]
    private Text buttonString = null;
    private GameObject target = null;
    private CallbackEvent callbackEvent = null;

    private Vector3 scale = new Vector3(0, 0, 0);
    private bool closeState = false;

    public void Init(string _text, CallbackEvent _callback, GameObject _target)
    {
        this.buttonString.text = _text;
        this.callbackEvent = _callback;
        this.target = _target;
    }

    private void Update()
    {
        if (closeState)
        {
            target.transform.localScale = Vector3.Lerp(transform.localScale, scale, Time.deltaTime * 10.0f);
        }
    }

    public void OnButton()
    {
        this.callbackEvent();
        Destroy(target);
    }
}