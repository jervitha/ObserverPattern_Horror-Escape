using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightSwitch : MonoBehaviour, I_Interactable
{
    [SerializeField] private List<Light> lightsources = new List<Light>();
    private SwitchState currentState;
    private void OnEnable()
    {
        EventService.Instance.LightSwitchToggleEvent.AddListener(OnLightsToggeled);
        EventManager.Instance.OnLightsOffByGhost += OnLightsOffByGhostEvent;
    }

    private void OnDisable()
    {
        EventService.Instance.LightSwitchToggleEvent.RemoveListener(OnLightsToggeled);
        EventManager.Instance.OnLightsOffByGhost -= OnLightsOffByGhostEvent;
    }

    private void Start()
    {
        currentState = SwitchState.Off;
    }

    public enum SwitchState
    {
        On,
        Off,
        Unresponsive
    }

    private void ToggleLights()
    {
        bool lights = false;

        switch (currentState)
        {
            case SwitchState.On:
                currentState = SwitchState.Off;
                lights = false;
                break;
            case SwitchState.Off:
                currentState = SwitchState.On;
                lights = true;
                break;
            case SwitchState.Unresponsive:
                break;
        }
        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    private void SetLights(bool lights)
    {
        if (lights)
        {
            currentState = SwitchState.On;
        }
        else
        {
            currentState = SwitchState.Off;
        }
        EventService.Instance.LightSwitchToggleEvent.InvokeEvent();

        foreach (Light lightSource in lightsources)
        {
            lightSource.enabled = lights;
        }
    }

    public void Interact()
    {
        UIManager.Instance.ShowInteractInstructions(false);
        EventService.Instance.LightSwitchToggleEvent.InvokeEvent();
    }
    private void OnLightsOffByGhostEvent()
    {
        SoundManager.Instance.PlaySoundEffects(SoundType.SwitchSound, false);
        SetLights(false);
    }
    private void OnLightsToggeled()
    {
        ToggleLights();
        SoundManager.Instance.PlaySoundEffects(SoundType.SwitchSound, false);
    }
}
