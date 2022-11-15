using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    public GameObject equipmentSlot;
    public Transform equipmentParent;
    
    public static EquipmentManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < SaveAndLoadManager.Instance.game.equipment.Count; x++)
        {
            GameObject obj = Instantiate(equipmentSlot, equipmentParent);
            
            // Disable the icon if the slot doesn't have any equipped item
            if(!SaveAndLoadManager.Instance.game.equipment[x].enabled)
                obj.transform.GetChild(0).gameObject.SetActive(false);
            
            // Focus border to show if item is equipped
            obj.transform.GetChild(3).gameObject.SetActive(false);
        }
    }

    public void Equip(Sprite icon)
    {
        for (int x = 0; x < SaveAndLoadManager.Instance.game.equipment.Count; x++)
        {
            if (!SaveAndLoadManager.Instance.game.equipment[x].enabled)
            {
                equipmentParent
                    .GetChild(x)
                    .transform
                    .GetChild(0)
                    .gameObject
                    .SetActive(true);

                equipmentParent
                    .GetChild(x)
                    .transform
                    .GetChild(0)
                    .gameObject.GetComponent<Image>().sprite = icon;
                
                SaveAndLoadManager.Instance.game.equipment[x].enabled = true;
                break;
            }
        }
    }
}
