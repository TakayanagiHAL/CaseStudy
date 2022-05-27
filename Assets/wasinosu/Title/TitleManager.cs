using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleManager : MonoBehaviour
{
    private InputAction AnyKeyAction = new InputAction(type: InputActionType.PassThrough, binding: "*/<Button>", interactions: "Press");

    private void OnEnable() => AnyKeyAction.Enable();
    private void OnDisable() => AnyKeyAction.Disable();

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.PlayBGM("タイトル");
    }

    // Update is called once per frame
    void Update()
    {
        if(AnyKeyAction.triggered)
        {
            //Any Key Pressed
            SoundManager.instance.PlaySE("海流");
        }
    }
}
