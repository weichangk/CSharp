using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public class InterfaceCls
    {
        public string InterfaceClsTest()
        {
            IWocao wocao = new Wocao();
            wocao.InterfaceEvent += (object o, EventArgs e) => { wocao.Name = "Wocao"; };
            return wocao.InterfaceFunc();
        }
    }

    public class Wocao : IWocao
    {
        object objectLock = new Object();

        public string Name { get; set; }

        //public event EventHandler InterfaceEvent;

        private event EventHandler _interfaceEvent;

        event EventHandler IWocao.InterfaceEvent
        {
            add
            {
                lock (objectLock)
                {
                    _interfaceEvent += value;
                }
            }

            remove
            {
                lock (objectLock)
                {
                    _interfaceEvent -= value;
                }
            }
        }

        public string InterfaceFunc()
        {
            _interfaceEvent?.Invoke(null, null);
            return Name;
        }
    }
    public interface IWocao
    {
        public string Name { get; set; }
        public string InterfaceFunc();

        event EventHandler InterfaceEvent;

    }
}
