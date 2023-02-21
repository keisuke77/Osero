
using UnityEngine;
using DG.Tweening;
namespace osero
{
    
    public enum komatype
     {
        white,black,none
     }
     [System.Serializable]
    public class koma  {
        public komatype komatype;
        public GameObject komaobj;
        public Vector2 Adress;
    

        public void Change(komatype komatypes){
           
            komatype=komatypes; 
            komaobj.transform.DORotate(new Vector3(180,0,0),0.6f);
            switch (komatypes)
            {
                case komatype.white: komaobj.GetComponent<Renderer>().material.color=Color.white;
                    break;
                    case komatype.black: komaobj.GetComponent<Renderer>().material.color=Color.black;
                    break;  
                    case komatype.none: komaobj.GetComponent<Renderer>().material.color=new Color(0,0,0,0);
                    break;
                default:
                    break;
            }
 
        }
    }
}