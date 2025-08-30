using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
namespace TCS {
    public class VisualElementNotClickthroughable : MonoBehaviour {
        UIDocument m_document;
        VisualElement m_root;

        [Header("Element tags to make not clickthroughable")]
        public List<string> m_elementTags = new();
        readonly List<VisualElement> m_childrenNotClickthroughable = new();

        void Awake() {
            m_document = GetComponent<UIDocument>();
            m_root = m_document.rootVisualElement;
        }

        /*void OnEnable() {
            //m_root.RegisterCallback<MouseEnterEvent>(_ => OnMouseEnter());
            //m_root.RegisterCallback<MouseLeaveEvent>(OnMouseLeave);

            foreach (string s in m_elementTags) {
                var element = m_root.Q<VisualElement>(s);
                if (element == null) continue;
                element.RegisterCallback<MouseEnterEvent>(_ => OnMouseEnter());
                element.RegisterCallback<MouseLeaveEvent>(OnMouseLeave);
                m_childrenNotClickthroughable.Add(element);
            }
        }*/

void OnEnable() {
            //m_root.RegisterCallback<MouseEnterEvent>(_ => OnMouseEnter());
            //m_root.RegisterCallback<MouseLeaveEvent>(OnMouseLeave);

            // foreach (string s in m_elementTags) {
            //     var element = m_root.Q<VisualElement>( s );
            //     if ( element == null ) continue;
            //     element.RegisterCallback<MouseEnterEvent>( _ => OnMouseEnter() );
            //     element.RegisterCallback<MouseLeaveEvent>( OnMouseLeave );
            //     m_childrenNotClickthroughable.Add( element );
            // }
        }

        bool wasOverElement = false;

        void Update() {
            var mousePos = Input.mousePosition;
            var screenPos = new Vector2( mousePos.x, Screen.height - mousePos.y );

            bool isOverElement = false;
            if ( m_root?.panel != null ) {
                var element = m_root.panel.Pick( screenPos );
                if ( element != null ) {
                    var currentElement = element;
                    while (currentElement != null) {
                        if ( m_elementTags.Contains( currentElement.name ) ) {
                            isOverElement = true;
                            break;
                        }

                        currentElement = currentElement.parent;
                    }
                }
            }

            if ( isOverElement && !wasOverElement ) {
                OnMouseEnter();
            }
            else if ( !isOverElement && wasOverElement ) {
                OnMouseLeave( null );
            }

            wasOverElement = isOverElement;


        }

        void OnDisable() {
            // m_root.UnregisterCallback<MouseEnterEvent>( _ => OnMouseEnter() );
            // m_root.UnregisterCallback<MouseLeaveEvent>( OnMouseLeave );

            // foreach (var element in m_childrenNotClickthroughable) {
            //     element.UnregisterCallback<MouseEnterEvent>( _ => OnMouseEnter() );
            //     element.UnregisterCallback<MouseLeaveEvent>( OnMouseLeave );
            // }
            //
            // m_childrenNotClickthroughable.Clear();
        }

        void OnMouseEnter() {
            TransparentWindowEvents.OnForceNotClickThrough?.Invoke();
            Debug.Log( "OnForceNotClickthrough event invoked" );


        }

        void OnMouseLeave(MouseLeaveEvent evt) {
            TransparentWindowEvents.OnForceClickThrough?.Invoke();
            Debug.Log( "OnForceClickthrough event invoked" );


        }
    }
}