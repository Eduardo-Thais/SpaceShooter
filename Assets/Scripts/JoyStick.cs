using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace JoyStickNameSpace
{

    public class JoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        public Image bgJoystick, stick;
        private Vector3 inputVector;

        public void OnDrag(PointerEventData ped) 
        {
            Vector2 pos;
            if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgJoystick.rectTransform, ped.position, ped.pressEventCamera, out pos))
            {
                pos.x = pos.x/bgJoystick.rectTransform.sizeDelta.x;
                pos.y = pos.y/bgJoystick.rectTransform.sizeDelta.y;

                inputVector = new Vector3(pos.x * 2 - 1, 0, pos.y * 2 - 1);

                if(inputVector.magnitude > 1)
                {
                    inputVector = inputVector.normalized;
                }

                float sizeBg = bgJoystick.rectTransform.sizeDelta.x / 4;

                stick.rectTransform.anchoredPosition = new Vector3(inputVector.x * sizeBg, inputVector.z * sizeBg, 0);
            }

        }
        public void OnPointerDown(PointerEventData ped)
        {
            OnDrag(ped);
        }
        public void OnPointerUp(PointerEventData ped)
        {
            inputVector = Vector3.zero;
            stick.rectTransform.anchoredPosition = Vector3.zero;
        }

        public float Horizontal()
        {
            return inputVector.x;
        }
        public float Vertical()
        {
            return inputVector.z;
        }

    }

}
