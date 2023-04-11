using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
   public int Index;
   public int Value;
   public GameObject Front;
   public GameObject Back;
   public bool IsOpen;
   public bool CanRotate = true;
   private float duration = 0.1f;
   private RotateMode mode = RotateMode.FastBeyond360;
   private bool isRotation;

   public void Toggle() => Toggle(null);
   public void Show() => Show(null);
   public void Hide() => Hide(null);
   public void Toggle(Action  callback)
   {
      if(isRotation) return;
      if(IsOpen) Hide(callback); 
      else Show(callback);
   }

   
   public void Show(Action  callback)
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
               callback?.Invoke();
            });
         });
      }
   }
   public void Hide(Action  callback)
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
               CanRotate = true;
               callback?.Invoke();
            });
         });
      }
   }

   public Vector2 GetImageSizePerPixel()
   {
      var image = Front.GetComponent<Image>();
      Sprite sprite = image.sprite;
      
      int textureWidth = sprite.texture.width;
      int textureHeight = sprite.texture.height;
      
      Rect spriteRect = sprite.rect;
      
      int spriteWidth = (int)(textureWidth * spriteRect.width / sprite.textureRect.width);
      int spriteHeight = (int)(textureHeight * spriteRect.height / sprite.textureRect.height);
      return new Vector2(spriteWidth, spriteHeight);
   } 

   private void SetActiveFrontSide(bool status)
   {
      Back.SetActive(!status);
      Front.SetActive(status);
   }
}
