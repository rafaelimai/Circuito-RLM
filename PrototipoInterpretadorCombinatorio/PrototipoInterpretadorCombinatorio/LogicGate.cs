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

            output = new StatePoint(0,false);
            A.setOwner(this); 
            B.setOwner(this);
            this.input1 = A;
            this.input2 = B; 
        }

        public void evaluate()
        {
            if (input1 == null && input2 == null)
            {
                throw new Exception("Logic gate must have at least one StatePoint");

            }
            else if (input1 != null && input2 == null && input1.getCurrentValue() != StatePoint.UNDEFINED)
            {
                //Single State point logic gate. (e.g, NOT gate)

                //Code for single state point gates must be written here.


            }
            else if (input1.getCurrentValue() != StatePoint.UNDEFINED || input2.getCurrentValue() != StatePoint.UNDEFINED)
            {

                /*
                 * The code that models the logic gate function needs to be codified in this method, in classes that extend LogicGate.
                 */
                
            }
                      
        }

        //Reset the logic gate input ports, so the entire circuit parsing can be done correctly again.
        public void reset()
        {
            input1.setUndefined();
            input2.setUndefined();
            output.setUndefined();
        }

    }
}
