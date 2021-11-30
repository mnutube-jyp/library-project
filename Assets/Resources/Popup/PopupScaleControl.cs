using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupScaleControl
{
    private GameObject target = null;
    private Vector3 openScaleValue = new Vector3(1.0f, 1.0f, 1.0f);
    private Vector3 closeScaleValue = new Vector3(0f, 0f, 0f);
    public bool openState = false;
    public bool closeState = false;
    private float openTime;
    private float closeTime;


    public PopupScaleControl(GameObject _target)
    {
        this.target = _target;
    }


    public void handlePopupScale ()
    {
        if(openState)
        {
            this.target.transform.localScale = Vector3.Lerp(target.transform.localScale, openScaleValue, Time.deltaTime * 10.0f);
            openTime += Time.deltaTime;
        }

        if(openTime > 1f)
        {
            openState = false;
        }

        if (closeState)
        {
            this.target.transform.localScale = Vector3.Lerp(target.transform.localScale, closeScaleValue, Time.deltaTime * 10.0f);
            closeTime += Time.deltaTime;
        }

        if (closeTime > 1f)
        {
            closeState = false;
        }
    }
}
