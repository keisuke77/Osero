using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
 namespace osero
{
  public enum nowturn
   {
    black,white
   }
    
    public class GameSystem : MonoBehaviour {
        public GameObject TouchEffect;
        public nowturn nowturn;
        public board board;
        public koma TouchKoma;
        public message message;
        public TMPro.TextMeshProUGUI scoretext;
        public TMPro.TextMeshProUGUI turntext;
        public Image turnimage;

void Start()
{int n=(int)board.boardsize/2;
    board.SetUp();
    board.komas[n-1,n].Change(komatype.black);
    board.komas[n,n-1].Change(komatype.black);
    board.komas[n,n].Change(komatype.white);
    board.komas[n-1,n-1].Change(komatype.white);
    message.SetMessagePanel("先行は白からだ。",true);
}

public void KomaTryPlace(){
                   switch (nowturn)
        {
            case nowturn.white:
            if (TouchKoma.komatype==komatype.none)
            {DetectKomaAndChanges(TouchKoma);
            if (changeable)
            {
            TouchKoma.Change(komatype.white);
            nowturn=nowturn.black;
    message.SetMessagePanel("黒のターンになった。",true);
            }else
            {
                
    message.SetMessagePanel("この場所にはおけないみたいだ。",true);
            }
               
                
            }
            
                break;
                case nowturn.black:
                 if (TouchKoma.komatype==komatype.none)
            {
               DetectKomaAndChanges(TouchKoma);
            if (changeable)
            {
            TouchKoma.Change(komatype.black);
            
            nowturn=nowturn.white;
            
    message.SetMessagePanel("白のターンになった。",true);
            }else
            {
    message.SetMessagePanel("この場所にはおけないみたいだ。",true);
            }

                  }
                break;
            default:
                break;
        }
        board.Counter();

}




        void Update()
        {   changeable=false;
                 TouchKoma=TouchGetKoma();
            if (TouchKoma!=null)
            {              
                KomaTryPlace();
            }if (scoretext!=null)
            {
               scoretext.text="白"+board.whitecount.ToString()+"枚"+"　黒"+board.blackcount.ToString()+"枚";
        
            }if (turntext!=null)
            {
            turntext.text=nowturn==nowturn.black?"黒のターン":"白のターン";
            }if (turnimage!=null)
            {
            turnimage.material.color=nowturn==nowturn.black?Color.black:Color.white;
            }
          }

public void DetectKomaAndChanges(koma komas){
for (var i = -1; i < 2; i++)
{
    for (var j = -1; j < 2; j++)
    {
        DetectKomaAndChange(komas, new Vector2(i,j));
    }
}
}

Vector2 Search;
List<koma> ChangeKomas;
bool changeable;
        public void DetectKomaAndChange(koma komas,Vector2 direction){
            if (komas==null)
            {
                return;
            }
Search=Vector2.zero;
Search+=direction;  
ChangeKomas= new List<koma>();
 if (board.komas[(int)komas.Adress.x+(int)Search.x,(int)komas.Adress.y+(int)Search.y]==null)
    {
        return;
    }
switch (nowturn)
{
 
    case nowturn.white:

    while (board.komas[(int)komas.Adress.x+(int)Search.x,(int)komas.Adress.y+(int)Search.y].komatype==komatype.black)
    {
        ChangeKomas.Add(board.komas[(int)komas.Adress.x+(int)Search.x,(int)komas.Adress.y+(int)Search.y]);
        Search+=direction;
         if (board.komas[(int)komas.Adress.x+(int)Search.x,(int)komas.Adress.y+(int)Search.y]==null)
    {
        return;
    }
    }

     if (board.komas[(int)komas.Adress.x+(int)Search.x,(int)komas.Adress.y+(int)Search.y].komatype==komatype.white)
    {
        foreach (var item in ChangeKomas)
        {
            item?.Change(komatype.white);
            changeable=true;
        }
        
    }

        break;  
        case nowturn.black:

    while (komatype.white==board.komas[(int)komas.Adress.x+(int)Search.x,(int)komas.Adress.y+(int)Search.y].komatype)
    {
        ChangeKomas.Add(board.komas[(int)komas.Adress.x+(int)Search.x,(int)komas.Adress.y+(int)Search.y]);
        Search+=direction;
         if (board.komas[(int)komas.Adress.x+(int)Search.x,(int)komas.Adress.y+(int)Search.y]==null)
    {
        return;
    }
    }

     if (komatype.black==board.komas[(int)komas.Adress.x+(int)Search.x,(int)komas.Adress.y+(int)Search.y].komatype)
    {
        foreach (var item in ChangeKomas)
        {
            item?.Change(komatype.black);
            changeable=true;
        }
    }

        break;
    default:
        break;
}

        }

        public koma TouchGetKoma(){
            RaycastHit hit=keikei.mousePositionObj();
            if (hit.point!=Vector3.zero)
            {if (TouchEffect!=null)
            {
                Instantiate(TouchEffect,hit.point,Quaternion.identity);
            }
                 return board.GetKoma(hit.collider.gameObject);
            }
            return null;
             }
    }
}