using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public void OnButtonEvent()
    {
        PopupBuilder popupBuilder = new PopupBuilder(this.transform);
        popupBuilder.SetTitle("�˾� �׽�Ʈ");
        popupBuilder.SetDescription("�׽�Ʈ");

        popupBuilder.SetButton("���");
        popupBuilder.SetButton("Ȯ��");
        popupBuilder.Build();
    }
}
