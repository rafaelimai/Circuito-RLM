using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombinatoryParserPrototype
{
    /*
     * The class LogicGate makes an abstraction of real-life logic gates.
     * This abstraction is needed for programming purposes, such as processing the output of a Combinatory Circuit.
     * A visible assumption made here is that logic gates won't have more than two input ports.
     */
    public class LogicGate
    {
        private StatePoint input1;
        private StatePoint input2;
        private StatePoint output;
        

        /*
         * Default constructor.Although there are two standard inputs, one of them might be equal to null
         * (for example:NOT-gate)
         */
        public LogicGate(StatePoint A, StatePoint B)
        {

            output = new StatePoint(false,false);
            A.setOwner(this); 
            B.setOwner(this);
            this.input1 = A;
            this.input2 = B;
            this.output.setValue(processOutput());
        }

        public bool processOutput()
        {
            if (input1 == null && input2 == null)
            {
                throw new Exception("Logic gate must have at least one StatePoint");

            }

            /*
             * The code that models the logic gate function needs to be codified in this method, in classes that extend LogicGate.
             */

            return true;
                      
        }

    }
}
