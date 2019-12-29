using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heart : MonoBehaviour
{
    // Start is called before the first frame update
    Image heartBar;
    [Range(0, 100f)] [SerializeField] float maxHeart = 100f;
    public static float heart;
    // Start is called before the first frame update
    void Start()
    {
        heartBar = GetComponent<Image>();
        heart = maxHeart;
    }

    // Update is called once per frame
    void Update()
    {
        heartBar.fillAmount = heart / maxHeart;
    }
}
