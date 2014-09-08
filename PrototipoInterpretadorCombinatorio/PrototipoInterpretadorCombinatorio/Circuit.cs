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
        
        private List<Connection> connections;
        private List<StatePoint> inputPorts;
        private List<StatePoint> outputPorts;
        private List<LogicGate> logicGates;

        public Circuit()
        {
            connections = new List<Connection>();
            inputPorts = new List<StatePoint>();
            outputPorts = new List<StatePoint>();
            logicGates = new List<LogicGate>();
        }

        public void refreshOutputs()
        {

        }

        

        //Methods to add or remove input/output ports and logic gates
        
        public void addInputPort(StatePoint A)
        {
            inputPorts.Add(A);
        }

        public void addOutputPort(StatePoint A)
        {
            outputPorts.Add(A);
        }

        public void removeInputPort(StatePoint A)
        {
            inputPorts.Remove(A);
        }

        public void removeOutputPort(StatePoint A)
        {
            outputPorts.Remove(A);
        }

        public void addLogicGate(LogicGate gate)
        {
            logicGates.Add(gate);
        }

        public void removeLogicGate(LogicGate gate)
        {
            logicGates.Remove(gate);
        }

        public void connectTwoPoints(StatePoint A, StatePoint B)
        {
            Connection c = new Connection(A, B);
            connections.Add(c);
        }

        public void disconnectTwoPoints(StatePoint A, StatePoint B)
        {

            int i = 0;
            bool mustRun = true;

            while (i < connections.Count && mustRun)
            {
                Connection c = connections.ElementAt(i);
                if (c.getStartPoint().Equals(A) && c.getEndPoint().Equals(B))
                {
                    connections.Remove(c);
                    mustRun = false;
                } 
                //Trying to save some procedures.
            }
            
        }


        //Getters to retrieve the input/output ports, logic gates and connections. Can be used to graphical purposes.
        public List<StatePoint> getOutputPorts()
        {
            return outputPorts;
        }

        public List<StatePoint> getInputPorts()
        {
            return inputPorts;
        }

        public List<Connection> getConnections()
        {
            return connections;
        }

        public List<LogicGate> getLogicGates()
        {
            return logicGates;
        }

    }
}
