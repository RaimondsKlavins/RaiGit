using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyprConversions2.Classes
{
    class RaiClass
    {
        public event RaiDelegates.RaiVoidDelegate RaiVoidDelegateEvent;
        public event RaiDelegates.RaiStringDelegate RaiStringEvent;
        public event RaiDelegates.RaiOutStringDelegate RaiOutStringEvent;
        public event RaiDelegates.RaiButtonDelegate RaiButtonLikeEvent;
    }
}
