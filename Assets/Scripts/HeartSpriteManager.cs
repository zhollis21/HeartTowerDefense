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
    public Sprite PinkHeartSprite;

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

    public Sprite GetHeartSprite(Heart.Type heartType)
    {
        switch (heartType)
        {
            case Heart.Type.Red:
                return RedHeartSprite;
            case Heart.Type.Blue:
                return BlueHeartSprite;
            case Heart.Type.Green:
                return GreenHeartSprite;
            case Heart.Type.Yellow:
                return YellowHeartSprite;
            case Heart.Type.Pink:
                return PinkHeartSprite;
            default:
                Debug.LogError($"Sprite not found for {heartType}");
                return null;
        }
    }
}
