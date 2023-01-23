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
        while(checkAlive())
        {
            // En el while se comprueba si uno de los equipos tiene a todos muertos
            //Se elige aleatoriamente quien empieza primero Rojo=0, Azul=1
            string turno=rand.Next(2)==0 ? Turno(Rojo, Azul) : Turno(Azul, Rojo);
            Console.WriteLine(turno);
        }

        string Turno(List<Unit> atacante, List<Unit> defensor){
            //Seleccionamos la unidad atacante
            int unidadAtacante= rand.Next(atacante.Count);
            if(atacante[unidadAtacante].getLife()<=0){
                return "Lo siento los muertos no pueden atacar, no tienes un nigromante";
            }
            // Aqui generamos una lista de los defensores vivos porque siempre va a atacar a un vivo
            // La solucion del nombre del equipo
            List<Unit> defensoresVivos = new List<Unit>();
            foreach (Unit u in defensor)
            {
                if(u.getLife()>0)
                {
                    defensoresVivos.Add(u);
                }
            }
            // Seleccionamos la unidad que va a ser atacada
            int unidadDefensora= rand.Next(defensoresVivos.Count);
            defensoresVivos[unidadDefensora].Hit(atacante[unidadAtacante]);
            //Pendiente cambiar la estructura de la Unit para que se le asigne el equipo en el constructor
            return "Atacante del equipo ¿? y reduce la vida del defensor en  "+atacante[unidadAtacante].getAttack()+" de vida y el defensor del equipo ¿? se queda con "+defensoresVivos[unidadDefensora].getLife()+" de vida";
        }
        bool checkAlive(){
            bool rojoVivo = false;
            bool azulVivo = false;
            foreach (var u in Rojo)
            {
                if(u.getLife()>0){
                    rojoVivo=true;
                    break;
                }
            }
            foreach (var u in Azul)
            {
                 if(u.getLife()>0){
                    azulVivo=true;
                    break;
                }
            }
            return rojoVivo && azulVivo;
        }
        
    }
    public abstract class Unit
    {
        protected string team;
        private int life=20;
        private int attack=0;

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
    }

    public class Aldeano : Unit
    {
        public Aldeano(String team): base(0){
            base.team = team;
        }

        public string getClass()
        {
            return "Aldeano";
        }
        
    }

    public class Guerrero: Unit
    {
        public Guerrero(String team): base(10){
            base.team = team;
        }

        public string getClass()
        {
            return "Guerrero";
        }
        
    }

    public class Arquero: Unit
    {
        public Arquero(String team): base(5){
            base.team = team;
        }

        public string getClass()
        {
            return "Arquero";
        }
        
    }
}