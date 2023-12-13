using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDataToUI : MonoBehaviour
{
    [SerializeField] GameObject scoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;

    List<GameObject> uiElements = new List<GameObject>();

    //subsribe to the event in playerdatahandler
    private void OnEnable()
    {
        PlayerDataHandler.onplayerdataListChanged += UpdateUI;
    }

    private void OnDisable()
    {
        PlayerDataHandler.onplayerdataListChanged -= UpdateUI;
    }
    private void UpdateUI(List<ScoreElement> list)
    {
        Debug.Log(uiElements.Count);
        for (int i = 0; i < list.Count; i++)
        {
            ScoreElement el = list[i];
            Debug.Log(el.nameOfPlayer);

            if (i >= uiElements.Count)
            {
                //intantiate new entry
                var inst = Instantiate(scoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                inst.transform.SetParent(elementWrapper, false);
                
                uiElements.Add(inst);
            }
            var texts = uiElements[i].GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = el.nameOfPlayer;
            texts[1].text = el.playCountGame.ToString();
            
        }
    }
}
