using System.Collections.Generic;

namespace AllasPortal
{
    public class MunkaLista
    {
        public List<MunkaXML> Munkak { get; set; }

        public MunkaLista()
        {
            Munkak = new List<MunkaXML>();
        }
    }
}
