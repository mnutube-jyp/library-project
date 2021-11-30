using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CallbackEvent(); 

public class PopupButtonInfo {
    public string text = null; 
    public CallbackEvent callback = null; 

    public PopupButtonInfo(string _text, CallbackEvent _callback) { 
        this.text = _text; 
        this.callback = _callback == null ? () => {} : _callback; 
    } 
}

