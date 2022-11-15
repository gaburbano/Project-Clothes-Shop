using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject equipmentSlot;
    public Transform equipmentParent;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < SaveAndLoadManager.Instance.game.equipmentCount; x++)
        {
            GameObject obj = Instantiate(equipmentSlot, equipmentParent);
        }
    }
}
