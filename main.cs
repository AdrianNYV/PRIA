using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

public class Programa{

    public static void Main(){
        List<Unit> Rojo = new List<Unit>();
		List<Unit> Azul = new List<Unit>();
		Rojo.Add(new Aldeano());
		Rojo.Add(new Aldeano());
		Rojo.Add(new Guerrero());
		Rojo.Add(new Arquero());
		Azul.Add(new Aldeano());
		Azul.Add(new Aldeano());
		Azul.Add(new Guerrero());
		Azul.Add(new Arquero());
    }
    public abstract class Unit
    {
        private int life=20;
        private int attack=0;

        public Unit (int attack){
            this.attack=attack;
        }

        public void Hit(Unit defensor){
            int newLife= defensor.getLife()- this.getAttack();
            defensor.setLife(newLife);
        }

        public int getAttack(){
            return attack;
        }
        public int getLife(){
            return life;
        }
        public void setLife(int newLife){
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