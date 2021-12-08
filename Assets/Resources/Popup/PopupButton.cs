using UnityEngine;

public class PopupButton : MonoBehaviour
{
    [SerializeField]
    private GameObject target = null;
    private CallbackEvent callbackEvent = null;

    public void Init(CallbackEvent _callback, GameObject _target)
    {
        this.callbackEvent = _callback;
        this.target = _target;
    }

    public void OnButton()
    {
        this.callbackEvent();
        Destroy(target);
    }
}