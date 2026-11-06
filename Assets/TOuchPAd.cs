using UnityEngine;
using UnityEngine.InputSystem;

using UnityEngine.InputSystem.PS5;

public class TOuchPAd : MonoBehaviour
{
    [SerializeField] private float speed;
    DualSenseGamepad pad;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
/*
        pad.SetLightBarColor(Color.red);
        pad.SetVibrationMode(VibrationMode.Compatible);*/
       /* pad = DualSenseGamepad.GetBySlotIndex(0);*/
        //Debug.Log(pad);
        pad.SetLightBarColor(Color.red);

    }

    // Update is called once per frame
    void Update()
    {

        pad = DualSenseGamepad.GetBySlotIndex(0);
        pad.SetVibrationMode(VibrationMode.Compatible);
        //pad.SetMotorSpeeds(1f, 2f);


        PS5TouchControl touch0 = pad.touches[0];
        PS5TouchControl touch1 = pad.touches[1];

        //Get the phase of the touch
        UnityEngine.TouchPhase phase = (UnityEngine.TouchPhase)touch0.phase;
        //Touch is not valid when it's state is ended or none and will report position as (-1,-1)
        if (phase == UnityEngine.TouchPhase.Ended || phase == UnityEngine.TouchPhase.Canceled)
        {
            return;
        }

        int id = touch0.touchId.ReadValue();
        Vector2 position = touch0.position.ReadValue();
        Vector2 delta = touch0.delta;

        this.gameObject.transform.position = new Vector3(position.x * speed, position.y, 0);


        var effect = new UnityEngine.InputSystem.PS5.TriggerEffectParam(UnityEngine.InputSystem.PS5.TriggerEffectMask.L2 | UnityEngine.InputSystem.PS5.TriggerEffectMask.R2);

        effect.right.mode = UnityEngine.InputSystem.PS5.TriggerEffectMode.Weapon;
        effect.right.weapon.startPosition = 2;
        effect.right.weapon.endPosition = 8;
        effect.right.weapon.strength = 8;

        pad.SetTriggerEffect(effect);

    }
   public void OnJump(InputAction.CallbackContext context)
    {
        //gameObject.SetActive(false);
        pad.SetLightBarColor(Color.white);
        pad.SetMotorSpeeds(1f, 10f);
    }







  
}
