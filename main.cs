using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit
{
    private int life=20;
    private int atack=0;

    public Unit (int atack){
        this.atack=atack;
    }

    public Hit(Unit atacante, Unit defensor){
        int newLife= defensor.getVida()- atacante.getAtaque();
        setVida(newLife);
    }

    public getAtaque(){
        return atack;
    }
    public getVida(){
        return life;
    }
    public setVida(int newLife){
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