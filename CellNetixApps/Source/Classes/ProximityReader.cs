using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CellNetixApps.Source.Classes
{
    class ProximityReader
    {

        public static int ReadBadge()
        {
            byte[] idBuf = new byte[32];
            int idRaw = 0;
            int id = 0;
            int B = 8;
            short bits = RFIDeas_pcProxAPI.pcProxDLLAPI.getActiveID32(8);

            if (bits > 0)
            {

                for (short z = 0; z < B; z++)
                {
                    idBuf[(B - 1) - z] = RFIDeas_pcProxAPI.pcProxDLLAPI.getActiveID_byte(z);
                }
                if (bits > 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        int t = idRaw << 8;
                        int w = idBuf[i];
                        idRaw = (t) | w;
                    }
                    id = idRaw >> 1; // Remove Trailing parity
                    id = (int)(idRaw & 0x0ffffL);

                   
                }
            }

            return id;
        }
    }
}
