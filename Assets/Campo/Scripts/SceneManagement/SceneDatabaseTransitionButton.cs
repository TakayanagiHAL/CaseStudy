using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class SceneDatabaseTransitionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool interactable = true;
    private bool selected;
    private bool pressed;

    public Image targetGraphic;
    public Color normalColor = Color.white;
    public Color hoverColor = Color.white;
    public Color pressedColor = Color.gray;
    public Color disabledColor = Color.white;

    public ScenesData sceneDatabase;
    public SCENE_TYPE moveToSceneType;

    private void Awake()
    {
        targetGraphic = GetComponent<Image>();
    }

    private void Update()
    {
        if (!interactable)
        {
            targetGraphic.color *= disabledColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (interactable && !pressed)
        {
            targetGraphic.color *= normalColor;
        }
        selected = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (interactable)
        {
            targetGraphic.color *= normalColor;
            pressed = false;
        }

        if (interactable && selected)
        {
            sceneDatabase.MoveToLevel(moveToSceneType);
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (interactable)
        {
            targetGraphic.color *= pressedColor;
            pressed = true;
        }
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (interactable && !pressed)
        {
            targetGraphic.color *= hoverColor;
        }
        selected = true;
    }
}
