using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloVirus1
{
    class Config
    {
        public string serverUrl;
        public string encryptionKey;
        public string encryptionIv;

        public Config()
        {
            serverUrl = ""; // load from encrypted file
            encryptionKey = "";
            encryptionIv = "";
        }

    }
}
