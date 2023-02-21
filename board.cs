using UnityEngine;
namespace osero
{
  
    [System.Serializable]
    public class board {
        public GameObject komaobj;
        
        public koma[,] komas=new koma[20,20];
        [Range(6,15)]
        public int boardsize=8;
        public int whitecount;
        public int blackcount;
        
        public void Counter(){
whitecount=0;
blackcount=0;
  for (var x = 0; x < boardsize; x++)
        {
            for (var y = 0; y < boardsize; y++)
            {
                switch (komas[x,y].komatype)
                {
                    case komatype.black:
                    blackcount++;
                        break;
                        case komatype.white:
                    whitecount++;
                        break;
                    default:
                        break;
                }
                
            }
        }
        }

        public void SetUp(){
        for (var x = 0; x < boardsize; x++)
        {
            for (var y = 0; y < boardsize; y++)
            {komas[x,y]=new koma();
               komas[x,y].komaobj= keikei.Instantiate(komaobj,new Vector3(x,0,y),Quaternion.identity);
                komas[x,y].Change(komatype.none);
                 komas[x,y].Adress=new Vector2(x,y);
            }
        }
        }

        public koma GetKoma(GameObject obj){
        for (var x = 0; x < boardsize; x++)
        {
            for (var y = 0; y < boardsize; y++)
            {if (komas[x,y].komaobj==obj)
            {
                return komas[x,y];
            }
                   }
        }
        return null;
        }
    }
}