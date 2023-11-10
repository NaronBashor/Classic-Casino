using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpinButtonControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
        private float count = 0;

        private bool isHeld = false;

        private void Update()
        {
                if (isHeld)
                {
                        count += Time.deltaTime;
                }
                if (count > 1)
                {
                        GameObject.Find("ReelSymbolManager").GetComponent<ReelSymbolManager>().IsHeldDown = true;
                }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
                isHeld = true;
                GameObject.Find("ReelSymbolManager").GetComponent<ReelSymbolManager>().AutoSpin = false;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
                isHeld = false;
                count = 0;
        }
}
