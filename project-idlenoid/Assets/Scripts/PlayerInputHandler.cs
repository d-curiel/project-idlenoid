using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    
    public void HandleAction(InputAction.CallbackContext context)
    {
        if (context.action.IsPressed())
        {
            Vector2 clickPosition = context.ReadValue<Vector2>();
            Ray ray = Camera.main.ScreenPointToRay(clickPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                Debug.Log("Clic en: " + hitObject.name);

                // Aquí puedes agregar más lógica según el GameObject clicado
            }
        }
    }
}
