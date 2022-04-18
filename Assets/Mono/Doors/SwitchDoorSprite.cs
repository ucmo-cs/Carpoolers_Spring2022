using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoorSprite : MonoBehaviour
{
    
    public BoolSO isLocked;
    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    private SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (isLocked.value && spriteRenderer.sprite != lockedSprite) {
            spriteRenderer.sprite = lockedSprite;
        }
        else if (!isLocked.value && spriteRenderer.sprite != unlockedSprite) {
            spriteRenderer.sprite = unlockedSprite;
        }
    }
}
