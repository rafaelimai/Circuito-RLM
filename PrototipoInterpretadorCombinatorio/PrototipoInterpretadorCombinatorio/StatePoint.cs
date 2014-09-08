using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombinatoryParserPrototype
{

    /*
     * The class StatePoint intends to represent any point that may assume the values (TRUE,1,5V) or (FALSE,0,0V).
     * It can be used as the output point of a logic gates arrangement or as abstractions of the logic gates input ports.
     */
    class StatePoint
    {
        //Variable that stores the StatePoint value.We're assuming here that there won't be any losses on the circuit itself (the risk of having undefined values is disregarded).
        private bool currentValue = false;
        private bool isLogicGateInput;
        private LogicGate owner;

        //Point a, here, intends to represent an object that links StatePoint to something graphic.
        public StatePoint(/*Point a,*/ bool value, bool isLogicGateInput)
        {
            this.currentValue = value;
            this.isLogicGateInput = isLogicGateInput;
        }


        public void setValue(bool value)
        {
            this.currentValue = value;
        }

        public bool getCurrentValue()
        {
            return currentValue;
        }

        //Return true if this StatePoint is a Logic Gate input port.
        public bool isLogicGateInputPort()
        {
            return isLogicGateInput;
        }

        
        public void setInputPort(bool value)
        
        {
            this.isLogicGateInput = value;
            
        }

        public void setOwner(LogicGate owner)
        {
            this.owner = owner;
        }

        //Return the Logic Gate who owns this state point.
        public LogicGate getOwner()
        {
            return owner;
        }
    }
}
