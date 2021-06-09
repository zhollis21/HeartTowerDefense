using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpriteManager : MonoBehaviour
{
    public static HeartSpriteManager Instance;
    public Sprite RedHeartSprite;
    public Sprite BlueHeartSprite;
    public Sprite GreenHeartSprite;
    public Sprite YellowHeartSprite;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Sprite GetHeartSprite(Heart.HeartType heartType)
    {
        switch (heartType)
        {
            case Heart.HeartType.Red:
                return RedHeartSprite;
            case Heart.HeartType.Blue:
                return BlueHeartSprite;
            case Heart.HeartType.Green:
                return GreenHeartSprite;
            case Heart.HeartType.Yellow:
                return YellowHeartSprite;
        }

        Debug.LogError($"Sprite not found for {heartType}");
        return null;
    }
}
