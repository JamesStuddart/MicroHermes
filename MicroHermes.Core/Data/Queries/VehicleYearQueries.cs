﻿using System.Collections.Generic;
using System.Linq;

namespace MicroHermes.Core.Data.Queries
{
    public class VehicleYearQueries : IVehicleYearQueries
    {
        private readonly IDictionary<int,int> values;
        
        public VehicleYearQueries()
        {
            values = new Dictionary<int, int>
            {
                {1,2001},
                {2,2002},
                {3,2003},
                {4,2004},
                {5,2005},
                {6,2006},
                {7,2007},
                {8,2008},
                {9,2009},
                {10,2010},
                {11,2011},
                {12,2012},
                {13,2013},
                {14,2014},
                {15,2015},
                {16,2016},
            };
        }

        public int GetId(int value)
        {
            return values.First(x => x.Value.Equals(value)).Key;
        }
        
        public int GetValue(int id)
        {
            return values.First(x => x.Key.Equals(id)).Value;
        }
    }
}