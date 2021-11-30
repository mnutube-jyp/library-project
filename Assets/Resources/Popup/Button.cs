using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void OnButtonEvent()
    {
        PopupBuilder popupBuilder = new PopupBuilder(this.transform);
        popupBuilder.SetTitle("팝업 테스트");
        popupBuilder.SetDescription("테스트");

        popupBuilder.SetButton("취소");
        popupBuilder.SetButton("확인");
        popupBuilder.Build();
    }
}
