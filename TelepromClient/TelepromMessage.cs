using System.Collections.Generic;

namespace TelepromClient
{

    public class TelepromMessage
    {
        public string origen { get; set; }
        public List<Mensaje> mensajes { get; set; }
    }
}