using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;

public class Programa{

    public static void Main(){
        var rand = new Random();
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
        while(true)/*Aqui se comprobaria si algun equipo ha ganado, comprobando si alguna unidad tiene mas de 0 de vida*/
        {
            //Se elige aleatoriamente quien empieza primero Rojo=0, Azul=1
            if(rand.Next(2)==0)//Aqui solo entraria si empieza el rojo
            {
            // Ataca rojo
            Turno(Rojo, Azul);
            }else{	
           // Ataca Azul
            Turno(Azul, Rojo);
            }
          
            break;//Break temporal ya que no tenemos la condicion de terminar batalla
        }

        void Turno(List<Unit> atacante, List<Unit> defensor){
            // Aqui Se elegiria al azar una unidad que ataca y la unidad objetivo
            // Si la unidad que ataca esta muerta se terminaria el turno
            // Si la unidad que que es atacada esta muerta se eligiria otra unidad
        }
        
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