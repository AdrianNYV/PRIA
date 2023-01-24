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

        //Aqui clonamos las listas para usarlas como listas auxiliares para saber quienes estan vivos
        List<Unit> AzulLose = new List<Unit>();
        foreach(Unit i in Azul){
            AzulLose.Add(i);
        }
        List<Unit> RojoLose = new List<Unit>();
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
            // Si la unidad que va a atacar está muerta devolvemos el string y terminamos el turno
            if(atacante[unidadAtacante].getLife()<=0){
                return "Lo siento los muertos no pueden atacar, no tienes un nigromante\n";
            }
            // Seleccionamos la unidad que va a ser atacada
            int unidadDefensora= rand.Next(defensor.Count);
            //La unidad es atacada
            defensor[unidadDefensora].Hit(atacante[unidadAtacante]);
            // Creamos el texto del turno para que no de conflictos al quitar a la unidad en caso de que se muera
            string textoTurno=atacante[unidadAtacante].getCategory()+ " del equipo "+atacante[unidadAtacante].getTeam()+" reduce la vida del "+defensor[unidadDefensora].getCategory()+" del equipo "+defensor[unidadDefensora].getTeam()+" en "+atacante[unidadAtacante].getAttack()+" y este se queda con "+defensor[unidadDefensora].getLife()+" de vida\n";
            // Si esta muerto lo quitamos de la lista auxiliar
            if(defensor[unidadDefensora].getLife()<=0){
                defensor.Remove(defensor[unidadDefensora]);
            }
            return textoTurno;
        }
        bool checkAlive(){
            bool rojoVivo = false;
            bool azulVivo = false;
            if(RojoLose.Count>0){
                rojoVivo=true;
            }else if(RojoLose.Count ==0){
                // Si todos los del equipo Rojo estan muertos damos la victoria al equipo Azul
                winner= "Azul";
            }
            if(AzulLose.Count>0){
                azulVivo=true;
            }else if(AzulLose.Count ==0){
                // Si todos los del equipo Azul estan muertos damos la victoria al equipo Rojo
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
        protected string category;

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
        public string getCategory(){
            return category;
        }
    }

    public class Aldeano : Unit
    {
        public Aldeano(String team): base(0){
            base.team = team;
            base.category="Aldeano";
        }
    }

    public class Guerrero: Unit
    {
        public Guerrero(String team): base(10){
            base.team = team;
            base.category="Guerrero";
        }
        
    }

    public class Arquero: Unit
    {
        public Arquero(String team): base(5){
            base.team = team;
            base.category="Arquero";
        }
        
    }
}