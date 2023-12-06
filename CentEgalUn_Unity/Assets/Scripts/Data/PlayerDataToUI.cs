using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataToUI : MonoBehaviour
{
    [SerializeField] GameObject panel;
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
    private void UpdateUI(List<InputEntry> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            InputEntry el = list[i];

            if (el.playCountGame1 > 0)
            {
                if (i >= uiElements.Count)
                {
                    //intantiate new entry
                    var inst = Instantiate(scoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);
                    
                    uiElements.Add(inst);
                }
                var texts = uiElements[i].GetComponentsInChildren<Text>();
                texts[0].text = el.nameOfPlayer;
                texts[1].text = el.playCountGame1.ToString();
                texts[2].text = el.playCountGame2.ToString();
                texts[3].text = el.playCountGame3.ToString();

            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }


}
