//Authors:
//    18/01/23
//    Adrian Nicolas
//    David Corbelle
//    David Vidal

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
        Rojo.Add(new Aldeano("Rojo"));
        Rojo.Add(new Aldeano("Rojo"));
        Rojo.Add(new Guerrero("Rojo"));
        Rojo.Add(new Arquero("Rojo"));
        Azul.Add(new Aldeano("Azul"));
        Azul.Add(new Aldeano("Azul"));
        Azul.Add(new Guerrero("Azul"));
        Azul.Add(new Arquero("Azul"));
        while(true)/*Aqui se comprobaria si algun equipo ha ganado, comprobando si alguna unidad tiene mas de 0 de vida*/
        {
            //Se elige aleatoriamente quien empieza primero Rojo=0, Azul=1
            string turno=rand.Next(2)==0 ? Turno(Rojo, Azul) : Turno(Azul, Rojo);
            Console.WriteLine(turno);
            break;//Break temporal ya que no tenemos la condicion de terminar batalla
        }

        string Turno(List<Unit> atacante, List<Unit> defensor){
            // Aqui Se elegiria al azar una unidad que ataca y la unidad objetivo
            // Si la unidad que ataca esta muerta se terminaria el turno
            // Si la unidad que que es atacada esta muerta se eligiria otra unidad
            return "Atacante x ataca a defensor y";
        }
        
    }
    public abstract class Unit
    {
        private string team;
        private int life=20;
        private int attack=0;

        public Unit (int attack){
            this.attack=attack;
        }

        public void Hit(Unit defensor){
            int newLife= defensor.getLife()- this.getAttack();
            defensor.setLife(newLife);
        }

        public string getTeam(){
            return team;
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

        public void setTeam(string team){
            this.team = team;
        }

    }

    public class Aldeano : Unit
    {
        public Aldeano(String team): base(0){
            base.setTeam(team);
        }
        
    }

    public class Guerrero: Unit
    {
        public Guerrero(String team): base(10){
            base.setTeam(team);
        }
        
    }

    public class Arquero: Unit
    {
        public Arquero(String team): base(5){
            base.setTeam(team);
        }
        
    }
}