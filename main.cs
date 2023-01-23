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
        string winner="";
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
        List<Unit> AzulLose= new List<Unit>();
        foreach(Unit i in Azul){
        AzulLose.Add(i);
        }
        List<Unit> RojoLose= new List<Unit>();
        foreach(Unit i in Rojo){
        RojoLose.Add(i);
        }
        while(checkAlive())
        {
            // En el while se comprueba si uno de los equipos tiene a todos muertos
            //Se elige aleatoriamente quien empieza primero Rojo=0, Azul=1
            string turno=rand.Next(2)==0 ? Turno(Rojo, AzulLose) : Turno(Azul, RojoLose);
            Console.WriteLine(turno);
        }
         Console.WriteLine("El ganador es el equipo "+winner);

        string Turno(List<Unit> atacante, List<Unit> defensor){
            //Seleccionamos la unidad atacante
            int unidadAtacante= rand.Next(atacante.Count);
            if(atacante[unidadAtacante].getLife()<=0){
                return "Lo siento los muertos no pueden atacar, no tienes un nigromante\n";
            }
            // Aqui generamos una lista de los defensores vivos porque siempre va a atacar a un vivo
            // La solucion del nombre del equipo
           
            // Seleccionamos la unidad que va a ser atacada
            int unidadDefensora= rand.Next(defensor.Count);
            defensor[unidadDefensora].Hit(atacante[unidadAtacante]);
            Unit defensorTmp= defensor[unidadDefensora];
            if(defensor[unidadDefensora].getLife()<=0){
                defensor.Remove(defensor[unidadDefensora]);
            }
            //Pendiente cambiar la estructura de la Unit para que se le asigne el equipo en el constructor
            return  atacante[unidadAtacante].getClass()+ " del equipo "+atacante[unidadAtacante].getTeam()+" reduce la vida del "+defensorTmp.getClass()+" del equipo "+defensorTmp.getTeam()+" en "+atacante[unidadAtacante].getAttack()+" y este se queda con "+defensorTmp.getLife()+" de vida\n";
        }
        bool checkAlive(){
            bool rojoVivo = false;
            bool azulVivo = false;
            if(RojoLose.Count>0){
                rojoVivo=true;
            }else if(RojoLose.Count ==0){
                winner= "Azul";
            }
            if(AzulLose.Count>0){
                azulVivo=true;
            }else if(AzulLose.Count ==0){
                winner= "Rojo";
            }
            return rojoVivo && azulVivo;
        }
        
    }
    public abstract class Unit
    {
        protected string team;
        private int life=20;
        private int attack=0;
        protected string clase;

        public Unit (int attack){
            this.attack=attack;
        }

        public void Hit(Unit atacante){
            int newLife= this.getLife()- atacante.getAttack();
            this.setLife(newLife);
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
        public string getClass(){
            return clase;
        }
    }

    public class Aldeano : Unit
    {
        public Aldeano(String team): base(0){
            base.team = team;
            base.clase="Aldeano";
        }
    }

    public class Guerrero: Unit
    {
        public Guerrero(String team): base(10){
            base.team = team;
            base.clase="Guerrero";
        }
        
    }

    public class Arquero: Unit
    {
        public Arquero(String team): base(5){
            base.team = team;
            base.clase="Arquero";
        }
        
    }
}