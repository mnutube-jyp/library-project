using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopupOpenCanvus : MonoBehaviour
{
    private string clickedButtonName = null;
    private string popupImagePath = null;

    public void OnButtonEvent()
    {
        PopupBuilder popupBuilder = new PopupBuilder(this.transform);

        clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        if(clickedButtonName != null)
        {
            switch (clickedButtonName)
            {
                case "LoanButton":
                    popupImagePath = "LoanReturn";
                    break;
                case "SearchButton":
                    popupImagePath = "Search";
                    break;
            }

            popupBuilder.SetImage(popupImagePath);
            popupBuilder.SetButton();
            popupBuilder.Build();
        }
    }
}
