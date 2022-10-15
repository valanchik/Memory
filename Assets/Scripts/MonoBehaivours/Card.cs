using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{
   public int Index;
   public int Value;
   public GameObject Front;
   public GameObject Back;
   public bool IsOpen;
   private float duration = 0.1f;
   private RotateMode mode = RotateMode.FastBeyond360;
   private bool isRotation;
   public void Toggle()
   {
      if(isRotation) return;
      if(IsOpen) Hide(); 
      else Show();
   }

   public void Show()
   {
      if (!IsOpen)
      {
         isRotation = true;
         transform.DORotate(transform.localRotation.eulerAngles+new Vector3(0, 90, 0), duration, mode).OnComplete(() =>
         { 
            SetActiveFrontSide(true);
            transform.DORotate(transform.localRotation.eulerAngles + new Vector3(0, 90, 0), duration, mode).OnComplete(() =>
            {
               IsOpen = true;
               isRotation = false;
            });
         });
      }
   }
   public void Hide()
   {
      if (IsOpen)
      {
         isRotation = true;
         transform.DORotate(transform.localRotation.eulerAngles+new Vector3(0, -90, 0), duration, mode).OnComplete(() =>
         { 
            SetActiveFrontSide(false);
            transform.DORotate(transform.localRotation.eulerAngles + new Vector3(0, -90, 0), duration, mode).OnComplete(() =>
            {
               IsOpen = false;
               isRotation = false;
            });;
           
         });
      }
   }

   private void SetActiveFrontSide(bool status)
   {
      Back.SetActive(!status);
      Front.SetActive(status);
   }
}
