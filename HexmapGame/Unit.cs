using HexmapGame.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexmapGame
{
    public abstract class Unit
    {
        public string? name; //unit name
        public int healthPoints; //amount of health point the unit has
        public int attackValue; //damage value for said unit
        public int movePoints; //number of movement points the unit can use each turn
        public bool attack = true; //true - attack available, false - already attacked this turn

        //used unit images by Null Tale from https://nulltale.itch.io/heroes-chess 
        public Bitmap bmp = null!; //CS8618

       abstract public void ResetUnitStatus(); //restores movePoints and attack
    }

    abstract class Infantry : Unit
    {
        public Infantry()
        {
            name = "Infantry";
            healthPoints = 4;
            attackValue = 2;
            movePoints = 3;
        }

        override public void ResetUnitStatus()
        {
            movePoints = 3;
            attack = true;
        }
    }

    class InfantryB : Infantry
    {
        public InfantryB()
        {
            bmp = new Bitmap(Resources.InfantryB);
        }
    }
    
    class InfantryR : Infantry
    {
        public InfantryR()
        {
            bmp = new Bitmap(Resources.InfantryR);
        }
    }

    abstract class Knight : Unit
    {
        public Knight()
        {
            name = "Knight";
            healthPoints = 6;
            attackValue = 3;
            movePoints = 3;
        }

        override public void ResetUnitStatus()
        {
            movePoints = 3;
            attack = true;
        }
    }

    class KnightB : Knight
    {
        public KnightB()
        {
            bmp = new Bitmap(Resources.KnightB);
        }
    }

    class KnightR : Knight
    {
        public KnightR()
        {
            bmp = new Bitmap(Resources.KnightR);
        }
    }

    abstract class Cavalry : Unit
    {
        public Cavalry()
        {
            name = "Cavalry";
            healthPoints = 8;
            attackValue = 4;
            movePoints = 4;
        }

        override public void ResetUnitStatus()
        {
            movePoints = 4;
            attack = true;
        }
    }

    class CavalryB : Cavalry
    {
        public CavalryB()
        {
            bmp = new Bitmap(Resources.CavalryB);
        }
    }

    class CavalryR : Cavalry
    {
        public CavalryR()
        {
            bmp = new Bitmap(Resources.CavalryR);
        }
    }

    abstract class Mage : Unit
    {
        public Mage()
        {
            name = "Mage";
            healthPoints = 2;
            attackValue = 6;
            movePoints = 6;
        }

        override public void ResetUnitStatus()
        {
            movePoints = 6;
            attack = true;
        }
    }

    class MageB : Mage
    {
        public MageB()
        {
            bmp = new Bitmap(Resources.MageB);
        }
    }

    class MageR : Mage
    {
        public MageR()
        {
            bmp = new Bitmap(Resources.MageR);
        }
    }
}
