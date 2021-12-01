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
                case "CafeButton":
                    popupImagePath = "Cafe";
                    break;
                case "EnglishButton":
                    popupImagePath = "Englishbook";
                    break;
                case "KoreanButton":
                    popupImagePath = "Koreanbook";
                    break;
                case "EconomyButton":
                    popupImagePath = "Economybook";
                    break;
                case "HistoryButton":
                    popupImagePath = "Historybook";
                    break;
                case "MusicButton":
                    popupImagePath = null;
                    popupBuilder.setVideo();
                    break;
            }

            popupBuilder.SetImage(popupImagePath);
            popupBuilder.SetButton();
            popupBuilder.Build();
        }
    }
}
