using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ToggleLightsButton : MonoBehaviour
{
    // create camera list that can be updated in the inspector
    public List<Light> Lights;

    // create frame and button variables 
    private VisualElement frame;
    private Button button;

    // This function is called when the object becomes enabled and active.
    void OnEnable()
    {
        // get the UIDocument component (make sure this name matches!)
        var uiDocument = GetComponent<UIDocument>();
        // get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame1");
        // get the button, which is nested in the frame
        button = frame.Q<Button>("Button1");
        // create event listener that calls ToggleLights() when pressed
        button.RegisterCallback<ClickEvent>(ev => ToggleLights());
    }

    // initialize click count
    int click = 1;
    private void ToggleLights(){
        click += 1;
        if ((click % 3) == 1) {
            Lights.ForEach(light => light.enabled = true);
            Lights.ForEach(light => light.intensity = light.intensity * 2f);
        }
        else if ((click % 3) == 2) {
            Lights.ForEach(light => light.enabled = true);
            Lights.ForEach(light => light.intensity = light.intensity * 0.5f);
        }
        else if ((click % 3) == 0) {
            Lights.ForEach(light => light.enabled = false);
        }
    }
    
}
