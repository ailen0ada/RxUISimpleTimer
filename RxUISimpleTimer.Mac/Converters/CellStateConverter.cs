using System;
using ReactiveUI;
using Splat;
using AppKit;
using System.Runtime.Remoting.Messaging;

namespace RxUISimpleTimer.Mac.Converters
{
    public class CellStateConverter : IBindingTypeConverter, IEnableLogger
    {
        public CellStateConverter()
        {
        }

        #region IBindingTypeConverter implementation

        public int GetAffinityForObjects(Type fromType, Type toType)
        {
            // any number other than 0 signifies conversion is possible.
            return (fromType == typeof(bool) || fromType == typeof(NSCellStateValue))
                ? 1 : 0;
        }

        public bool TryConvert(object from, Type toType, object conversionHint, out object result)
        {
            result = toType == typeof(bool) 
                ? (object)ToBoolean((NSCellStateValue)from) 
                : (object)ToCellState((bool)from);
            return true;
        }

        private NSCellStateValue ToCellState(bool b) => b ? NSCellStateValue.On : NSCellStateValue.Off;

        private bool ToBoolean(NSCellStateValue s) => s == NSCellStateValue.On;

        #endregion
    }
}

