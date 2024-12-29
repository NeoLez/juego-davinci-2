using System;
using System.Collections.Generic;
using TilemapExperiments.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DrawingInterface : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    [SerializeField] private bool clear;
    [SerializeReference] private List<GameObject> buttons;
    [SerializeReference] private List<OrderAgnosticByteTuple> connectionsMade;
    public static event Action<SpellSO> SpellDrawnEvent; 

    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }
    
    private bool buttonHolding;
    private GameObject lastAreaPressed;
    void Update()
    {
        if (clear)
        {
            clear = false;
            if (connectionsMade.Count > 0)
            {
                var spells = Manager.Instance.spells;
                if (spells.Count < 3)
                {
                    var spellSO = SpellDatabase.FindSpellFromPattern(new DrawingPattern(connectionsMade));
                    if (spellSO is not null)
                    {
                        spells.Add(spellSO);
                    }
                    else
                    {
                        Debug.Log("No se pudo encontrar patron");
                    }
                }
            }
            
            ResetDrawing();
        }
        if (Input.GetMouseButtonDown(0))
        {
            buttonHolding = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            buttonHolding = false;
        }
        
        if(buttonHolding) {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            m_Raycaster.Raycast(m_PointerEventData, results);
            
            if (results.Count > 1)
            {
                GameObject newAreaPressed = results[0].gameObject;
                if (lastAreaPressed is null)
                {
                    lastAreaPressed = newAreaPressed;
                }
                if (lastAreaPressed != newAreaPressed) 
                {
                    OrderAgnosticByteTuple newConnection = new OrderAgnosticByteTuple(
                        (byte)buttons.IndexOf(lastAreaPressed), 
                        (byte)buttons.IndexOf(newAreaPressed)
                        );
                    
                    if (!connectionsMade.Contains(newConnection))
                    {
                        connectionsMade.Add(newConnection);
                        Debug.Log("Connection Made");
                    }
                    lastAreaPressed = newAreaPressed.gameObject;
                }
            }
        }
        else
        {
            lastAreaPressed = null;
        }
        
        Manager.Instance.spells.ForEach(
            s => Debug.Log(s.name)
            );
    }

    public void ResetDrawing()
    {
        connectionsMade.Clear();
    }

    
}
