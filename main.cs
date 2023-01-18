using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

public class Programa{

    public static void Main(){
       
    }
    public abstract class Unit
    {
        private int life=20;
        private int attack=0;

        public Unit (int attack){
            this.attack=attack;
        }

        public void Hit(Unit defensor){
            int newLife= defensor.getVida()- this.getAtaque();
            defensor.setVida(newLife);
        }

        public int getAtaque(){
            return attack;
        }
        public int getVida(){
            return life;
        }
        public void setVida(int newLife){
            this.life=newLife;
        }

    }

    public class Aldeano : Unit
    {
        public Aldeano(): base(0){}
        
    }

    public class Guerrero: Unit
    {
        public Guerrero(): base(10){}
        
    }

    public class Arquero: Unit
    {
        public Arquero(): base(5){}
        
    }
}