using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Mana : MonoBehaviour
{
    // Start is called before the first frame update
    Image ManaBar;
    [Range(0, 100f)] [SerializeField] float maxMana = 100f;
    public static float mana;
    // Start is called before the first frame update
    void Start()
    {
        ManaBar = GetComponent<Image>();
        mana = maxMana;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        ManaBar.fillAmount = mana / maxMana;
    }
}
