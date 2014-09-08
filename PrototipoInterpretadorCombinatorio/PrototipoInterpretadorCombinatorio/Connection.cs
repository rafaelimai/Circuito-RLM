using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CombinatoryParserPrototype
{
    class Connection
    {
        /*
         * The class connection represent a connection between two given points (called here as Start Point and End Point). Connection handling is processed in the class Circuit.
         */

        private StatePoint startPoint;
        private StatePoint endPoint;

        public Connection(StatePoint startPoint, StatePoint endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        public StatePoint getEndPoint()
        {
            return endPoint;
        }

        public StatePoint getStartPoint()
        {
            return startPoint;
        }
    }
}
