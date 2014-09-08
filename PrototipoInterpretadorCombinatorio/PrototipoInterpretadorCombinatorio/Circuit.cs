using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombinatoryParserPrototype
{

    /*
     * The class circuit intends to abstract a real life circuit.
     * As a real-life circuit, there can be as many input or output ports and logical gates as needed.
     * Note: The statement above applies to hardware limitations.
     */
    class Circuit
    {
        private Dictionary<StatePoint, StatePoint> connections;
        private List<StatePoint> inputPorts;
        private List<StatePoint> outputPorts;


        public void refreshOutputs()
        {

        }
    }
}
