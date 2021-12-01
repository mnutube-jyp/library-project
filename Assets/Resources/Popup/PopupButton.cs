using UnityEngine;
using UnityEngine.UI;

public class PopupButton : MonoBehaviour
{
    [SerializeField]
    private Text buttonString = null;
    private GameObject target = null;
    private CallbackEvent callbackEvent = null;

    public void Init(string _text, CallbackEvent _callback, GameObject _target)
    {
        this.buttonString.text = _text;
        this.callbackEvent = _callback;
        this.target = _target;
    }

    public void OnButton()
    {
        this.callbackEvent();
        Destroy(target);
    }
}