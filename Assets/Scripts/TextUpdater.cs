using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    public enum TextType { Lives, Money, Round }

    public TextType Type;

    private Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (Type)
        {
            case TextType.Money:
                _text.text = $"${GameManager.Instance.Money}";
                break;
            case TextType.Round:
                _text.text = $"Round: {GameManager.Instance.Round}";
                break;
            case TextType.Lives:
            default:
                _text.text = $"Lives: {GameManager.Instance.Lives}";
                break;
    }
    }
}
