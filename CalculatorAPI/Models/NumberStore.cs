﻿using CalculatorAPI.Interfaces;
using static CalculatorAPI.Models.Helpers;

namespace CalculatorAPI.Models
{
    public class NumberStore : INumberStore
    {
        private static Dictionary<Guid, Numbers> numbersDict { get; set; } = new Dictionary<Guid, Numbers>();

        /// <summary>
        /// removes values from numbersDict for a given guid
        /// </summary>
        /// <param name="guid"></param>
        public void Clear(Guid guid)
        {
            numbersDict.Remove(guid);
        }

        /// <summary>
        /// returns the numbers from numbersDict for a given guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Numbers Retrieve(Guid guid)
        {
            if (numbersDict.ContainsKey(guid))
            {
                return numbersDict[guid]; 
            } else {
                return new Numbers(); 
            }
        }

        /// <summary>
        /// adds the numbers to numberDict for a given guid
        /// </summary>
        /// <param name="number"></param>
        /// <param name="guid"></param>
        /// <param name="position"></param>
        public void Store(double number, Guid guid, Position position)
        {
            // If the location does not exist in numbersDict, add to numbersDict
            if (!numbersDict.ContainsKey(guid)) 
            {
                Numbers newnums = new Numbers();
                
                if (position == Position.Left) { newnums.LeftNumber = number; } else { newnums.RightNumber = number; }

                numbersDict.Add(guid, newnums);
            }
            // If the location already exists, update existing Numbers 
            else
            {
                Numbers oldnums = numbersDict[guid];

                if (position == Position.Left)
                {
                    oldnums.LeftNumber = number;
                }
                else
                {
                    oldnums.RightNumber = number;
                }

                numbersDict[guid] = oldnums;
            }

        }
    }
}
