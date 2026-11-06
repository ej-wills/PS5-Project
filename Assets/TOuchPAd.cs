using System;
using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine.InputSystem.PS5;

public class TOuchPAd : MonoBehaviour
{
    [SerializeField] private float speed;
    DualSenseGamepad pad;
    [SerializeField] private AudioSource vibrationSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
/*
        pad.SetLightBarColor(Color.red);
        pad.SetVibrationMode(VibrationMode.Compatible);*/
       /* pad = DualSenseGamepad.GetBySlotIndex(0);*/
        //Debug.Log(pad);

    }

    // Update is called once per frame
    void Update()
    {

        pad = DualSenseGamepad.GetBySlotIndex(0);
        pad.SetVibrationMode(VibrationMode.AdvancedAndCompatible);
        pad.SetLightBarColor(Color.red);
        //pad.SetMotorSpeeds(1f, 2f);


       


        var effect = new UnityEngine.InputSystem.PS5.TriggerEffectParam(UnityEngine.InputSystem.PS5.TriggerEffectMask.L2 | UnityEngine.InputSystem.PS5.TriggerEffectMask.R2);

        effect.right.mode = UnityEngine.InputSystem.PS5.TriggerEffectMode.Weapon;
        effect.right.weapon.startPosition = 3;
        effect.right.weapon.endPosition = 8;
        effect.right.weapon.strength = 8;



        pad.SetTriggerEffect(effect);

    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        //gameObject.SetActive(false);
        pad.SetLightBarColor(Color.white);
       // pad.SetMotorSpeeds(1f, 2f);

        vibrationSource.gamepadSpeakerOutputType = GamepadSpeakerOutputType.Vibration;

        //panStereo will effect the motor left (-1f) or right (1f) that will play the audio effect
        //0 will play on both motors equally
        vibrationSource.panStereo = .8f;
    }

    public void OnRightTrigger(InputAction.CallbackContext context)
    {
        //gameObject.SetActive(false);
        pad.SetLightBarColor(Color.white);
        pad.SetMotorSpeeds(0, 1f);
    }

    public void OnLeftTrigger(InputAction.CallbackContext context)
    {
        //gameObject.SetActive(false);
        pad.SetLightBarColor(Color.white);
        pad.SetMotorSpeeds(5f, 7f);
    }








}
