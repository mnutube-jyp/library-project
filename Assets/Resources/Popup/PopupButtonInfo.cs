public delegate void CallbackEvent();

public class PopupButtonInfo
{
    public CallbackEvent callback = null;

    public PopupButtonInfo(CallbackEvent _callback)
    {
        this.callback = _callback == null ? () => { } : _callback;
    }
}