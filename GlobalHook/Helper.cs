using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalHooks
{
    static class Helper
    {
        /// <summary>
        /// Retrieves the High Order Word from a 32-bit unsigned integer and returns it as a 16-bit signed integer.
        /// </summary>
        /// <param name="_uint">The 32-bit unsigned integer where the High Order Word is stored.</param>
        /// <returns>Returns a 16 bit signed integer as the High Order Word.</returns>
        public static short GetSignedHWORD(uint _uint)
        {
            return (short)((_uint >> 16) & 0xFFFF); //Shift the leftmost 16 bits to the right and mask the leftmost 16 bits. Get the rightmost 16 bits by casting the whole thing to a short value. (16 bit integer)
        }
        /// <summary>
        /// Retrieves the Low Order Word from a 32-bit unsigned integer and returns it as a 16-bit signed integer.
        /// </summary>
        /// <param name="_uint">The 32-bit unsigned integer where the Low Order Word is stored.</param>
        /// <returns>Returns a 16 bit signed integer as the Low Order Word.</returns>
        public static short GetSignedLWORD(uint _uint)
        {
            return (short)(_uint & 0xFFFF);  //No need to shift the bits since we just need the rightmost 16 bits. All we have to do is mask the leftmost 16 bits and cast the whole thing to a short value. (16 bit integer.)
        }

        /// <summary>
        /// Retrieves the High Order Word from a 32-bit unsigned integer and returns it as a 16-bit unsigned integer.
        /// </summary>
        /// <param name="_uint">The 32-bit unsigned integer where the High Order Word is stored.</param>
        /// <returns>Returns a 16 bit unsigned integer as the High Order Word.</returns>
        public static ushort GetUnsignedHWORD(uint _uint)
        {
            return (ushort)((_uint >> 16) & 0xFFFF);
        }

        /// <summary>
        /// Retrieves the Low Order Word from a 32-bit unsigned integer and returns it as a 16-bit unsigned integer.
        /// </summary>
        /// <param name="_uint">The 32-bit unsigned integer where the Low Order Word is stored.</param>
        /// <returns>Returns a 16 bit unsigned integer as the Low Order Word.</returns>
        public static ushort GetUnsignedLWORD(uint _uint)
        {
            return (ushort)(_uint & 0xFFFF);
        }
    }
}
